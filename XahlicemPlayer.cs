using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using XahlicemMod.UI;

namespace XahlicemMod {

    public class XahlicemPlayer : ModPlayer {
        private long lastHurt = 0;
        public long LastHurt { get { return lastHurt; } set { lastHurt = value; } }

        public int Level { get; set; }
        public int Souls { get; set; }
        public int SoulCost(int level) {
            return (int)(Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(3.06 * level, 2) + 105.6 * level) * 0.1, 0) * 10);
        }
        public int Str { get; set; }
        public float Melee { get { return 0.6f + Str * 0.02f; } }
        public int Dex { get; set; }
        public float Ranged { get { return 0.6f + Dex * 0.02f; } }
        public float Throwing { get { return 0.6f + ((Str < Dex) ? Str : Dex) * 0.04f; } }
        public int Int { get; set; }
        public float Magic { get { return 0.6f + Int * 0.02f; } }
        public int Fth { get; set; }
        public float Summon { get { return 0.6f + Fth * 0.01f; } }
        public int Vit { get; set; }
        public int Health { get { return Vit * 10; } }
        public int Att { get; set; }
        public int Mana { get { return Att * 5; } }

        public bool SoulSummon { get; set; }
        public bool EvilEye { get; set; }

        public override void Initialize() {
            Level = 0;
            Souls = 0;
            Str = 0;
            Dex = 0;
            Int = 0;
            Fth = 0;
            Vit = 0;
            Att = 0;

            SoulSummon = false;
            EvilEye = false;
        }

        public override void ResetEffects() {
            SoulSummon = false;
            EvilEye = false;
        }

        public override void PreUpdate() { }

        public override void ProcessTriggers(TriggersSet triggersSet) { }

        public override void SetControls() {
            if (UI.XPlayerUI.visible) {
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
            if (player.armor[0].type == mod.ItemType<Items.Armor.ChannelerHelmet>() &&
                player.armor[1].type == mod.ItemType<Items.Armor.ChannelerRobe>() &&
                player.armor[2].type == mod.ItemType<Items.Armor.ChannelerSkirt>())
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
                GetPacket((byte) XModMessageType.FromClient).Send();
            }
            if (player.Equals(Main.LocalPlayer))(mod as XahlicemMod).xUI.updateValue(Souls, Level);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lastHurt = 0;
            player.AddBuff(mod.BuffType<Buffs.Hollow>(), (int)(damage * 120.0));
        }

        public override void UpdateDead() {
            player.AddBuff(mod.BuffType<Buffs.Hollow>(), 60);

            if (Souls != 0) {
                int i = Item.NewItem((int) player.position.X, (int) player.position.Y, player.width, player.height, mod.ItemType("Soul"), Souls);
                Main.item[i].GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer = player.whoAmI;
                Souls = 0;
                if (player.Equals(Main.LocalPlayer))(mod as XahlicemMod).xUI.updateValue(Souls, Level);
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
            save.Add("XLevel", Level);
            save.Add("XSouls", Souls);
            save.Add("XStr", Str);
            save.Add("XDex", Dex);
            save.Add("XInt", Int);
            save.Add("XFth", Fth);
            save.Add("XVit", Vit);
            save.Add("XAtt", Att);
            return save;
        }

        public override void Load(TagCompound tag) {
            Level = tag.GetInt("XLevel");
            Souls = tag.GetInt("XSouls");
            Str = tag.GetInt("XStr");
            Dex = tag.GetInt("XDex");
            Int = tag.GetInt("XInt");
            Fth = tag.GetInt("XFth");
            Vit = tag.GetInt("XVit");
            Att = tag.GetInt("XAtt");
        }

        public override void SetupStartInventory(IList<Item> items) {
            items.Clear();
            Item item = new Item();
            item.netDefaults(mod.ItemType<Items.Melee.SwordHilt>()); //mod.ItemType<Items.Shop.HomewardBone>());
            item.prefix = PrefixID.Broken;
            items.Add(item);
        }

        public override void clientClone(ModPlayer clone) {
            base.clientClone(clone);
            (clone as XahlicemPlayer).Souls = Souls;
            (clone as XahlicemPlayer).lastHurt = lastHurt;
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