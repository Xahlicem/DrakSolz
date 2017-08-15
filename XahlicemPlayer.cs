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

namespace XahlicemMod {

    public class XahlicemPlayer : ModPlayer {

        public XahlicemRace xahlicemRace = XahlicemRace.Human;
        public bool xahlicemWet = false;
        public int xahlicemTick = 0;

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemRace", (byte) xahlicemRace }
            };
        }

        public override void Load(TagCompound tag) {
            xahlicemRace = (XahlicemRace) tag.GetByte("xahlicemRace");
        }

        public override void ResetEffects() {
            xahlicemWet = false;
        }

        public override void UpdateDead() {
            xahlicemWet = false;
        }

        public override void PreUpdateBuffs() {
            xahlicemTick++;
            if (xahlicemTick >= 600) xahlicemTick = 0;

            if (xahlicemRace == XahlicemRace.Demon) {
                player.lavaRose = true;
                //player.lavaImmune = true;
                player.lavaMax = 600;
                xahlicemWet = (player.FindBuffIndex(BuffID.Wet)) != -1 || player.wet;
                if (player.lavaWet || player.honeyWet) {
                    xahlicemWet = false;
                    player.ClearBuff(BuffID.Wet);
                }
                if (xahlicemWet && xahlicemTick % 30 == 0) player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " Choke'd on his spit!"), 5, 0);
            } else if (xahlicemRace == XahlicemRace.Ant) {
                player.maxRunSpeed = 100;
            }
        }

        public override void FrameEffects() {
            if (xahlicemRace == XahlicemRace.Ant)
                player.head = mod.GetEquipSlot("MoonlightHead", EquipType.Head);
        }

        public void DoStuff() {
            xahlicemRace = xahlicemRace.NextEnum();
            Main.NewText("Race = " + xahlicemRace, 255, 255, 255);
        }
    }

    public enum XahlicemRace : byte {
        Human,
        Demon,
        Ant
    }
}