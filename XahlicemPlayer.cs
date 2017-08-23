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
        public float lifeMod = 1f;

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemLifeMod", lifeMod }
            };
        }

        public override void PostUpdate() {
            XUI.visible = !Main.playerInventory;
            int souls = 0;
            for (int i = 0; i < player.inventory.Length; i++) {
                if (player.inventory[i].type == mod.ItemType<Items.Craft.Soul>()) souls += player.inventory[i].stack;
            }
            (mod as XahlicemMod).xUI.updateValue(souls);
        }

        public override void Load(TagCompound tag) {
            lifeMod = tag.GetFloat("xahlicemLifeMod");
        }

        /*public override void OnRespawn(Player player) {
            player.AddBuff(mod.BuffType<Buffs.Homeward>(), 60);
        }*/

        public override void UpdateDead() {
            lifeMod = 0.2f;
        }

        public override void PreUpdateBuffs() {
            if (Main.time % 60 == 0) {
                lifeMod += (player.FindBuffIndex(mod.BuffType<Buffs.Firelink>()) != -1) ? 0.1f : 0.002f;
                if (lifeMod > 1.5f) lifeMod = 1.5f;
            }
            player.statLifeMax2 = (int)(player.statLifeMax2 * lifeMod);
            if (player.statLife < 0) player.statLife = 0;
            if (player.statMana < 0) player.statMana = 0;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lifeMod -= (float)(damage / player.statLifeMax2) / 2.5f;
            if (lifeMod < 0.2f) lifeMod = 0.2f;
        }
    }
}