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
using XahlicemMod.UI;

namespace XahlicemMod {

    public class XahlicemPlayer : ModPlayer {
        private long lastHurt = 0;
        public long LastHurt { get { return lastHurt; } set { lastHurt = value; } }

        public int Souls { get; set; }

        public override TagCompound Save() {
            return new TagCompound { { "XSouls", Souls }
            };
        }

        public override void PostUpdate() {
            if (Main.netMode == NetmodeID.MultiplayerClient && player.Equals(Main.LocalPlayer)) {
                GetPacket((byte) XModMessageType.FromClient).Send();
            }
            if (player.Equals(Main.LocalPlayer))(mod as XahlicemMod).xUI.updateValue(Souls);
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
                if (player.Equals(Main.LocalPlayer))(mod as XahlicemMod).xUI.updateValue(Souls);
            }
        }

        public override void PreUpdateBuffs() {
            lastHurt++;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lastHurt = 0;
            player.AddBuff(mod.BuffType<Buffs.Hollow>(), (int)(damage * 120.0));
        }

        public override bool PreItemCheck() {

            return base.PreItemCheck();
        }

        public override void PostItemCheck() {

        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) { }
    }
}