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
        const float LifeModMax = 1.25f;
        private float lifeMod = 1f;
        private long lastHurt = 0;

        public int Souls { get; set; }

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemLifeMod", lifeMod }, { "XSouls", Souls }
            };
        }

        public override void PostUpdate() {
            //XUI.visible = !Main.playerInventory;
            (mod as XahlicemMod).xUI.updateValue(Souls);

            for (int i = 0; i < player.inventory.Length; i++) {
                if (player.inventory[i].stack != 0) Main.NewText(i + " " + player.inventory[i].Name + " " + player.inventory[i].active, Color.Yellow);
            }
            Main.NewText(player.inventory.Length.ToString());
        }

        public override void Load(TagCompound tag) {
            lifeMod = tag.GetFloat("xahlicemLifeMod");
            Souls = tag.GetInt("XSouls");
        }

        public override void OnRespawn(Player player) {
            lastHurt = 0;
        }

        public override void UpdateDead() {
            lifeMod = 0.2f;
        }

        public override void PreUpdateBuffs() {
            lastHurt++;
            if (Main.time % 60 == 0 && lastHurt >= 300) {
                lifeMod += (player.FindBuffIndex(mod.BuffType<Buffs.Firelink>()) != -1) ? 0.1f : 0.002f;
                if (lifeMod > LifeModMax) lifeMod = LifeModMax;
            }
            player.statLifeMax2 = (int)(player.statLifeMax2 * lifeMod);
            if (player.statLife < 0) player.statLife = 0;
            if (player.statMana < 0) player.statMana = 0;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lifeMod -= (float)(damage / player.statLifeMax2) / 2.5f;
            if (lifeMod < 0.2f) lifeMod = 0.2f;
            lastHurt = 0;
        }
    }
}