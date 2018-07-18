using System;
using System.Collections.Generic;
using System.IO;
using DrakSolz.Items;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz {

    public class DrakSolzPlayer : ModPlayer {
        private long lastHurt = 0;
        public long LastHurt { get { return lastHurt; } set { lastHurt = value; } }

        public int Level { get { return Vit + Str + Dex + Att + Int + Fth; } }
        public int Souls { get; set; }
        public int SoulCost(int level) {
            return (int)(Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 10);
        }
        public int Str { get; set; }
        public float Melee { get { return 0.6f + Str * 0.02f; } }
        public int Dex { get; set; }
        public float Ranged { get { return 0.6f + Dex * 0.02f; } }
        public float Throwing { get { return 0.6f + ((Str < Dex) ? Str : Dex) * 0.04f; } }
        public int Int { get; set; }
        public float Magic { get { return 0.6f + Int * 0.02f; } }
        public int Fth { get; set; }
        public float Summon { get { return 0.6f + Fth * 0.02f; } }
        public int Vit { get; set; }
        public int Health { get { return Level * 2 + Vit * 10 + (Vit > 20 ? (Vit - 20) * 5 : 0); } }
        public int Att { get; set; }
        public int Mana { get { return Att * 5; } }

        public float SoulTicks { get; set; }
        public int BossSoulTicks { get; set; }
        public int BossSouls { get; set; }

        public bool ZoneTowerVoidPillar;

        public bool SoulSummon { get; set; }
        public bool HumSummon { get; set; }

        public bool EvilEye { get; set; }
        public int Avarice { get; set; }

        public bool Rotate { get; set; }
        public float Rotation { get; set; }

        public override void Initialize() {
            Souls = 0;
            Str = 0;
            Dex = 0;
            Int = 0;
            Fth = 0;
            Vit = 0;
            Att = 0;

            SoulTicks = 0;
            BossSoulTicks = 0;
            BossSouls = 0;

            SoulSummon = false;
            HumSummon = false;
            EvilEye = false;
            Avarice = 0;

            Rotation = 0f;
        }

        public override void ResetEffects() {
            SoulSummon = false;
            HumSummon = false;
            EvilEye = false;
            Avarice = 0;
            Rotate = false;

            player.fullRotationOrigin = player.Center - player.position;
            player.fullRotation = Rotation;
        }

        public override void PreUpdate() {
            if (SoulTicks > 0) {
                float num = 0.5f;
                if (SoulTicks >= 10000) num = 10000;
                else if (SoulTicks >= 1000) num = 1000;
                else if (SoulTicks >= 100) num = 100;
                else if (SoulTicks >= 10) num = 5;
                SoulTicks -= num;
                if (num == 0.5f && SoulTicks % 1 != 0f) num = 1;
                Souls += (int) Math.Floor(num);
            }

            if (BossSoulTicks > 0) {
                if (BossSoulTicks <= 40) Souls += 25;
                else if (BossSoulTicks <= 80) Souls += 100;
                else if (BossSoulTicks <= 130) Souls += 500;
                else Souls += 1000;
                BossSoulTicks--;
                Main.dust[Dust.NewDust(player.position, player.width, player.height, DustID.AncientLight)].noGravity = true;
            }
        }

        public override void UpdateBiomes() {
            ZoneTowerVoidPillar = false;
            if (!player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula && !player.ZoneTowerStardust) {
                for (int i = 0; i < Main.maxNPCs; i++) {
                    var npc = Main.npc[i];
                    if (npc != null && npc.active && npc.type == mod.NPCType<NPCs.Enemy.VoidPillar.VoidPillar>() && player.Distance(npc.Center) <= 4000f) {
                        ZoneTowerVoidPillar = true;
                    }
                }
            }
        }

        public override bool CustomBiomesMatch(Player other) {
            var modOther = other.GetModPlayer<DrakSolzPlayer>(mod);
            return ZoneTowerVoidPillar == modOther.ZoneTowerVoidPillar;
        }

        public override void CopyCustomBiomesTo(Player other) {
            var modOther = other.GetModPlayer<DrakSolzPlayer>(mod);
            modOther.ZoneTowerVoidPillar = ZoneTowerVoidPillar;
        }

        public override void SendCustomBiomes(BinaryWriter writer) {
            byte flags = 0;
            if (ZoneTowerVoidPillar) {
                flags |= 1;
            }
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader) {
            byte flags = reader.ReadByte();
            ZoneTowerVoidPillar = ((flags & 1) == 1);
        }

        public override void UpdateBiomeVisuals() {
            DrakSolzPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<DrakSolzPlayer>(mod);
            bool useWhite = ZoneTowerVoidPillar;
            player.ManageSpecialBiomeVisuals("DrakSolz:VoidPillar", useWhite);
        }

        public override void ProcessTriggers(TriggersSet triggersSet) { }

        public override void SetControls() {
            if (UI.PlayerUI.visible) {
                player.controlDown = false;
                player.controlUp = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlMount = false;
                player.controlThrow = false;
                player.controlSmart = false;
                player.controlTorch = false;
                player.controlMap = false;
                player.controlHook = false;
                player.controlInv = false;
                player.controlJump = false;
                player.controlQuickHeal = false;
                player.controlQuickMana = false;
                player.controlUseItem = false;
                player.controlUseTile = false;
            }
        }

        public override void PreUpdateBuffs() {
            lastHurt++;
        }

        public override void PostUpdateBuffs() {
            if (player.armor[0].type == mod.ItemType<Items.Armor.Channeler.ChannelerHelmet>() &&
                player.armor[1].type == mod.ItemType<Items.Armor.Channeler.ChannelerRobe>() &&
                player.armor[2].type == mod.ItemType<Items.Armor.Channeler.ChannelerSkirt>())
                player.extraAccessorySlots += 1;

            for (int n = 3; n < 8 + player.extraAccessorySlots; n++) {
                Item item = player.armor[n];
                if (item.type == mod.ItemType<Items.Accessory.RingTinyBeing>()) {
                    player.statLifeMax2 += 20;
                }
            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) { }

        public override void PostUpdateEquips() { }

        public override void PostUpdateMiscEffects() {
            UpdateStats();
        }

        public override void PostUpdateRunSpeeds() { }

        public override void PreUpdateMovement() { }

        public override void PostUpdate() {
            if (Main.netMode == NetmodeID.MultiplayerClient && player.Equals(Main.LocalPlayer)) {
                GetPacket((byte) MessageType.FromClient).Send();
            }
            if (player.Equals(Main.LocalPlayer))(mod as DrakSolz).ui.updateValue(Souls, Level);

            if (Rotate) Rotation += player.velocity.X * 0.025f;
            else Rotation = 0f;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lastHurt = 0;
            player.AddBuff(mod.BuffType<Buffs.Hollow>(), (int)(damage * 120.0));
        }

        public override void UpdateDead() {
            player.AddBuff(mod.BuffType<Buffs.Hollow>(), 60);

            if (Souls != 0) {
                int i = Item.NewItem((int) player.position.X, (int) player.position.Y, player.width, player.height, mod.ItemType<Items.Souls.Soul>(), Souls);
                Main.item[i].GetGlobalItem<Items.DSGlobalItem>().FromPlayer = player.whoAmI;
                Souls = 0;
                if (player.Equals(Main.LocalPlayer))(mod as DrakSolz).ui.updateValue(Souls, Level);
            }
        }

        public override void OnRespawn(Player player) {
            lastHurt = 0;
        }

        public void UpdateStats() {
            player.meleeDamage *= Melee;
            player.rangedDamage *= Ranged;
            player.thrownDamage *= Throwing;
            player.magicDamage *= Magic;
            player.minionDamage *= Summon;
            player.statLifeMax = 100 + Health;
            player.statManaMax = Mana;
        }

        public override TagCompound Save() {
            TagCompound save = new TagCompound();
            save.Add("Souls", Souls);
            save.Add("Str", Str);
            save.Add("Dex", Dex);
            save.Add("Int", Int);
            save.Add("Fth", Fth);
            save.Add("Vit", Vit);
            save.Add("Att", Att);
            save.Add("BossSouls", BossSouls);
            return save;
        }

        public override void Load(TagCompound tag) {
            Souls = tag.GetInt("Souls");
            Str = tag.GetInt("Str");
            Dex = tag.GetInt("Dex");
            Int = tag.GetInt("Int");
            Fth = tag.GetInt("Fth");
            Vit = tag.GetInt("Vit");
            Att = tag.GetInt("Att");
            BossSouls = tag.GetInt("BossSouls");
        }

        public override void SetupStartInventory(IList<Item> items) {
            items.Clear();
            Item item = new Item();
            item.netDefaults(mod.ItemType<Items.Melee.Sword>());
            item.GetGlobalItem<DSGlobalItem>().Owned = true;
            item.GetGlobalItem<DSGlobalItem>().FromPlayer = player.whoAmI;
            items.Add(item);
        }

        public override void clientClone(ModPlayer clone) {
            base.clientClone(clone);
            (clone as DrakSolzPlayer).lastHurt = lastHurt;
            int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
            if (index != -1) clone.player.AddBuff(mod.BuffType<Buffs.Hollow>(), player.buffTime[index]);
        }

        public ModPacket GetPacket(byte packetType) {
            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) packetType);
            packet.Write(this.player.whoAmI);
            packet.Write(Souls);
            packet.Write(lastHurt);

            return packet;
        }
    }
}