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
        public int SoulCost {
            get {
                return (int)(Math.Round((Math.Pow(0.02 * Level, 3) + Math.Pow(3.06 * Level, 2) + 105.6 * Level) * 0.1, 0) * 10);
            }
        }
        public int Melee { get; set; }
        public int Ranged { get; set; }
        public int Throwing { get; set; }
        public int Magic { get; set; }
        public int Summon { get; set; }

        public override void Initialize() {
            Level = 0;
            Souls = 0;
            Melee = 0;
            Ranged = 0;
            Throwing = 0;
            Magic = 0;
            Summon = 0;
        }

        public override void SetupStartInventory(IList<Item> items) {
            items.Clear();
            Item item = new Item();
            item.SetDefaults(ItemID.CopperAxe); //mod.ItemType<Items.Shop.HomewardBone>());
            item.prefix = PrefixID.Broken;
            items.Add(item);
        }

        public override TagCompound Save() {
            return new TagCompound { { "XSouls", Souls }
            };
        }

        public void UpdateStats() {
            player.meleeDamage = player.meleeDamage * (0.6f + Melee * 0.02f);
            player.rangedDamage = player.rangedDamage * (0.6f + Ranged * 0.02f);
            player.thrownDamage = player.thrownDamage * (0.6f + Throwing * 0.02f);
            player.magicDamage = player.magicDamage * (0.6f + Magic * 0.02f);
            player.minionDamage = player.minionDamage * (0.6f + Summon * 0.02f);
        }

        public override void PostUpdate() {
            if (Main.netMode == NetmodeID.MultiplayerClient && player.Equals(Main.LocalPlayer)) {
                GetPacket((byte) XModMessageType.FromClient).Send();
            }
            if (player.Equals(Main.LocalPlayer))(mod as XahlicemMod).xUI.updateValue(Souls, Level);

            UpdateStats();
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

        public override void Load(TagCompound tag) {
            Souls = tag.GetInt("XSouls");
        }

        public override void OnRespawn(Player player) {
            lastHurt = 0;
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

        public override void PreUpdateBuffs() {
            lastHurt++;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lastHurt = 0;
            player.AddBuff(mod.BuffType<Buffs.Hollow>(), (int)(damage * 120.0));
        }
    }
}