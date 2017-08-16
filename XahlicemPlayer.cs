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
        public int xahlicemHair = -1;
        public int xahlicemHead = 0;
        public Color xahlicemHairColor = default(Color);
        public Color xahlicemEye = default(Color);
        public Color xahlicemSkin = default(Color);

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemRace", (byte) xahlicemRace }, { "xahlicemHair", xahlicemHair }, { "xahlicemHairColor", xahlicemHairColor }, { "xahlicemEye", xahlicemEye }, { "xahlicemSkin", xahlicemSkin }
            };
        }

        public override void Load(TagCompound tag) {
            xahlicemRace = (XahlicemRace) tag.GetByte("xahlicemRace");
            xahlicemHair = tag.GetInt("xahlicemHair");
            xahlicemHairColor = tag.Get<Color>("xahlicemHairColor");
            xahlicemEye = tag.Get<Color>("xahlicemEye");
            xahlicemSkin = tag.Get<Color>("xahlicemSkin");
        }

        public override void ResetEffects() {
            xahlicemWet = false;
        }

        public override void UpdateDead() {
            xahlicemWet = false;
        }

        public override void PreUpdateBuffs() {
            xahlicemWet = (player.FindBuffIndex(BuffID.Wet)) != -1 || player.wet;
            if (player.lavaWet || player.honeyWet) {
                xahlicemWet = false;
                player.ClearBuff(BuffID.Wet);
            }

            switch (xahlicemRace) {
                case XahlicemRace.Human:
                    if (xahlicemHair != -1) player.hair = xahlicemHair;
                    if (xahlicemHairColor != default(Color)) player.hairColor = xahlicemHairColor;
                    if (xahlicemEye != default(Color)) player.eyeColor = xahlicemEye;
                    if (xahlicemSkin != default(Color)) player.skinColor = xahlicemSkin;
                    xahlicemHead = 0;
                    break;
                case XahlicemRace.Demon:
                    player.rangedDamage *= 0.8f;
                    player.magicDamage *= 1.25f;
                    player.manaCost *= 1.25f;
                    player.statLifeMax2 = (int)(player.statLifeMax2 * 0.8);

                    player.buffImmune[BuffID.OnFire] = true;
                    player.lavaRose = true;
                    player.fireWalk = true;
                    player.lavaMax = 600;
                    XahlicemPlayer p = player.GetModPlayer<XahlicemPlayer>();
                    if (Main.myPlayer == player.whoAmI && Main.time % 30 == 0 && p.xahlicemWet) {
                        player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " couldn't stand the water."), 5, 0);
                    }

                    if (xahlicemHair != -1) player.hair = xahlicemHair;
                    player.hairColor = Color.Black;
                    player.skinColor = Color.DarkRed;
                    player.eyeColor = Color.Red;
                    xahlicemHead = 0;
                    break;

                case XahlicemRace.Ant:
                    player.pickSpeed *= 0.75f;
                    player.maxRunSpeed += 1;
                    player.spikedBoots = 2;

                    player.hair = 15;
                    player.skinColor = new Color(75, 35, 15);
                    player.eyeColor = Color.Black;
                    xahlicemHead = 0;
                    break;

                case XahlicemRace.Slime:
                    player.noFallDmg = true;
                    player.jumpSpeedBoost += 1;
                    player.jumpBoost = true;
                    player.slippy = true;
                    player.AddBuff(BuffID.Slimed, 10);

                    if (player.wet) {
                        player.gravity = -0.5f;
                    }

                    if (xahlicemHair != -1) player.hair = xahlicemHair;
                    player.hairColor = new Color(0, 50, 250, 50);
                    player.skinColor = new Color(100, 150, 255, 50);
                    player.eyeColor = new Color(0, 50, 250, 50);
                    xahlicemHead = 0;
                    break;
                case XahlicemRace.Zombie:
                    player.ignoreWater = true;
                    player.breath = 100000;
                    player.moveSpeed *= 0.75f;
                    //player.runAcceleration *= 0.5f;
                    player.maxRunSpeed *= 0.75f;
                    player.accRunSpeed = 0;
                    player.rangedDamage *= 0.25f;
                    player.thrownVelocity *= 1.5f;
                    player.meleeDamage *= 1.25f;
                    player.meleeSpeed *= 0.5f;
                    player.statLifeMax2 = (int)(player.statLifeMax2 * 0.5);
                    player.lifeRegenTime = 5;
                    player.lifeRegen += player.statLifeMax2 / 25;

                    if (xahlicemHair != -1) player.hair = xahlicemHair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(205, 255, 150);
                    player.eyeColor = Color.Red;
                    xahlicemHead = 0;
                    break;
                case XahlicemRace.Goblin:
                    player.rangedDamage *= 1.25f;

                    if (xahlicemHair != -1) player.hair = xahlicemHair;
                    player.hairColor = Color.Gray;
                    player.skinColor = new Color(94, 152, 161);
                    player.eyeColor = Color.Red;
                    xahlicemHead = 217;
                    break;
                case XahlicemRace.Skeleton:
                    player.ignoreWater = true;
                    player.breath = 100000;
                    player.lifeRegenCount = 0;

                    player.hair = 15;
                    player.skinColor = new Color(153, 153, 117);
                    player.eyeColor = Color.Black;
                    xahlicemHead = 93;
                    break;
            }
        }

        public override void FrameEffects() {
            if (xahlicemHead != 0)
                player.head = xahlicemHead;
                //player.face = head;
        }
        sbyte head = 0;
        public void DoStuff() {
            if (xahlicemEye == default(Color)) xahlicemEye = player.eyeColor;
            if (xahlicemSkin == default(Color)) xahlicemSkin = player.skinColor;
            if (xahlicemHairColor == default(Color)) xahlicemHairColor = player.hairColor;
            if (xahlicemHair == -1) xahlicemHair = player.hair;
            xahlicemRace = xahlicemRace.NextEnum();
            Main.NewText("Race = " + xahlicemRace, 255, 255, 255);
            head++;
            Main.NewText(head.ToString(), 255, 255, 255);
        }
    }

    public enum XahlicemRace : byte {
        Human,
        Demon,
        Ant,
        Slime,
        Zombie,
        Goblin,
        Skeleton
    }
}