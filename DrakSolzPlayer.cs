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
        private readonly int HurtWaitMax = 3600;
        public int HurtWait { get; internal set; }
        public int HurtWaitDec { get; internal set; }
        public int Hollow { get; internal set; }
        public int HollowDec { get; internal set; }

        public int Level { get { return Vit + Str + Dex + Att + Int + Fth; } }
        public int Souls { get; set; }
        public int SoulCost(int level) {
            return (int) (Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 10);
        }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Int { get; set; }
        public int Fth { get; set; }
        public int Vit { get; set; }
        public int Att { get; set; }

        public float SoulTicks { get; set; }
        public int BossSoulTicks { get; set; }
        public int BossSouls { get; set; }

        public bool ZoneTowerVoidPillar;
        public bool VoidMonolith = false;

        public bool SoulSummon { get; set; }
        public bool HumSummon { get; set; }
        public bool SunSummon { get; set; }
        public bool IceSummon { get; set; }
        public bool FireSummon { get; set; }
        public bool DungeonSummon { get; set; }
        public bool SoulMassSum { get; set; }

        public bool CrystalPet { get; set; }

        public bool EvilEye { get; set; }
        public int Avarice { get; set; }

        public bool Rotate { get; set; }
        public float Rotation { get; set; }

        public override void Initialize() {
            HurtWait = 0;
            HurtWaitDec = 1;
            Hollow = 0;
            HollowDec = 1;

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
            SunSummon = false;
            IceSummon = false;
            FireSummon = false;
            DungeonSummon = false;
            SoulMassSum = false;
            CrystalPet = false;
            EvilEye = false;
            Avarice = 0;

            Rotation = 0f;
        }

        public override void ResetEffects() {
            SoulSummon = false;
            HumSummon = false;
            SunSummon = false;
            IceSummon = false;
            FireSummon = false;
            DungeonSummon = false;
            SoulMassSum = false;
            EvilEye = false;
            Avarice = 0;
            Rotate = false;

            player.fullRotationOrigin = player.Center - player.position;
            player.fullRotation = Rotation;
        }

        public void UpdateSouls(int inc) {
            SetSouls(Souls + inc);
        }

        public void SetSouls(int num) {
            Souls = num;
            SendPacket(MessageType.Souls);
        }

        public void SetBossSouls(int place) {
            BossSouls |= place;
            SendPacket(MessageType.Boss);
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
                UpdateSouls((int) Math.Floor(num));
            }

            if (BossSoulTicks > 0) {
                if (BossSoulTicks <= 40) UpdateSouls(25);
                else if (BossSoulTicks <= 80) UpdateSouls(100);
                else if (BossSoulTicks <= 130) UpdateSouls(500);
                else UpdateSouls(1000);
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
            bool useWhite = ZoneTowerVoidPillar || VoidMonolith;
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

        public override void PostUpdateEquips() {
            UpdateStats();
        }

        public override void PostUpdate() {
            if (player.Equals(Main.LocalPlayer)) (mod as DrakSolz).ui.updateValue(Souls, Level);

            if (Rotate) Rotation += player.velocity.X * 0.025f;
            else Rotation = 0f;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            HurtWait = HurtWaitMax;
            Hollow += (int) (damage * 120.0);

            if (Main.netMode != NetmodeID.SinglePlayer)
                SendPacket(MessageType.Hurt);
        }

        public override void UpdateDead() {
            Hollow += 30;
            HurtWait = HurtWaitMax;
            UpdateHollow();
            SendPacket(MessageType.Hurt);

            if (Souls != 0) {
                int i = Item.NewItem((int) player.position.X, (int) player.position.Y, player.width, player.height, mod.ItemType<Items.Souls.Soul>(), Souls);
                Main.item[i].GetGlobalItem<Items.DSGlobalItem>().FromPlayer = player.whoAmI;
                SetSouls(0);
                if (player.Equals(Main.LocalPlayer)) (mod as DrakSolz).ui.updateValue(Souls, Level);
                SendPacket(MessageType.Souls);
            }
        }

        public void LevelUp(int strength, int dexterity, int intelligence, int faith, int vitality, int attunement) {
            Str += strength;
            Dex += dexterity;
            Int += intelligence;
            Fth += faith;
            Vit += vitality;
            Att += attunement;

            SendPacket(MessageType.Stats);
        }

        private void UpdateStats() {
            player.meleeDamage *= 0.6f + Str * 0.02f;;
            player.rangedDamage *= 0.6f + Dex * 0.02f;;
            player.thrownDamage *= 0.6f + ((Str < Dex) ? Str : Dex) * 0.04f;;
            player.magicDamage *= 0.6f + Int * 0.02f;;
            player.minionDamage *= 0.6f + Fth * 0.02f;;
            player.statLifeMax = Level * 4 + 100;
            player.statLifeMax2 = player.statLifeMax + Vit * 11;
            player.statManaMax = 0;
            player.statManaMax2 += Att * 5;
            player.manaCost *= 1 - (Att * 0.005f);
            player.statDefense += (int) Math.Floor(Vit * 0.25f);

            UpdateHollow();
        }

        public void DecreaseHollow(int amount) {
            Hollow -= amount;
            if (Hollow < 0) Hollow = 0;
        }

        public void DecreaseHurtWait(int amount) {
            HurtWait -= amount;
            if (HurtWait < 0) HurtWait = 0;
        }

        private void UpdateHollow() {
            HurtWaitDec = 1;
            if (player.FindBuffIndex(BuffID.Regeneration) != -1) HurtWaitDec++;
            DecreaseHurtWait(HurtWaitDec);

            HollowDec = 1;
            if (player.FindBuffIndex(BuffID.Regeneration) != -1) HollowDec++;
            if (HurtWait == 0 && Hollow > 0) DecreaseHollow(HollowDec);

            if (Hollow > 0) player.AddBuff(mod.BuffType<Buffs.Hollow>(), (Hollow / HollowDec) + (HurtWait / HurtWaitDec));
            int life = (int) ((Hollow + 1) / 300f);
            player.statLifeMax2 -= life;
            int min = 20 + Vit * 5;
            if (player.statLifeMax2 < min) player.statLifeMax2 = min;

            if (Hollow == 0 && player.FindBuffIndex(mod.BuffType<Buffs.Hollow>()) != -1) player.ClearBuff(mod.BuffType<Buffs.Hollow>());
        }

        public override TagCompound Save() {
            TagCompound save = new TagCompound();
            save.Add("HurtWait", HurtWait);
            save.Add("Hollow", Hollow);
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
            HurtWait = tag.GetInt("HurtWait");
            Hollow = tag.GetInt("Hollow");
            Souls = tag.GetInt("Souls");
            Str = tag.GetInt("Str");
            Dex = tag.GetInt("Dex");
            Int = tag.GetInt("Int");
            Fth = tag.GetInt("Fth");
            Vit = tag.GetInt("Vit");
            Att = tag.GetInt("Att");
            BossSouls = tag.GetInt("BossSouls");
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
            items.Clear();
            Item item = new Item();
            item.netDefaults(mod.ItemType<Items.Melee.Sword>());
            item.GetGlobalItem<DSGlobalItem>().Owned = true;
            item.GetGlobalItem<DSGlobalItem>().FromPlayer = player.whoAmI;
            items.Add(item);
            Item item2 = new Item();
            item2.netDefaults(mod.ItemType<Items.Misc.InfoBook>());
            item2.GetGlobalItem<DSGlobalItem>().Owned = true;
            item2.GetGlobalItem<DSGlobalItem>().FromPlayer = player.whoAmI;
            items.Add(item2);
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
            SendPacket(MessageType.Hurt, toWho, fromWho);
            SendPacket(MessageType.Stats, toWho, fromWho);
            SendPacket(MessageType.Souls, toWho, fromWho);
            SendPacket(MessageType.Boss, toWho, fromWho);
        }

        public override void clientClone(ModPlayer clone) {
            base.clientClone(clone);
            DrakSolzPlayer p = clone as DrakSolzPlayer;
            p.Str = Str;
            p.Dex = Dex;
            p.Int = Int;
            p.Fth = Fth;
            p.Vit = Vit;
            p.Att = Att;
            p.Hollow = Hollow;
            p.BossSouls = BossSouls;
            p.Souls = Souls;
        }

        public override void SendClientChanges(ModPlayer clientPlayer) {
            if ((clientPlayer as DrakSolzPlayer).Level != Level) SendPacket(MessageType.Stats);
        }

        public override void OnEnterWorld(Player player) {
            foreach (Item i in player.inventory)
                if (i.type > 0 && i.GetGlobalItem<DSGlobalItem>().FromPlayer == 0) i.GetGlobalItem<DSGlobalItem>().FromPlayer = this.player.whoAmI;
        }

        public void SendPacket(MessageType packetType, int toWho = -1, int fromWho = -1) {
            if (Main.netMode == NetmodeID.SinglePlayer) return;

            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) packetType);
            packet.Write((byte) this.player.whoAmI);
            if (packetType == MessageType.Stats) {
                packet.Write(Str);
                packet.Write(Dex);
                packet.Write(Int);
                packet.Write(Fth);
                packet.Write(Vit);
                packet.Write(Att);
            }
            if (packetType == MessageType.Hurt) {
                packet.Write(HurtWait);
                packet.Write(Hollow);
            }
            if (packetType == MessageType.Boss) {
                packet.Write(BossSouls);
            }
            if (packetType == MessageType.Souls) {
                packet.Write(Souls);
            }
            packet.Send(toWho, fromWho);
        }
    }
}