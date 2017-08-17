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

        public enum Race : byte {
            Human,
            Demon,
            Ant,
            Slime,
            Zombie,
            Goblin,
            Skeleton
        }
        public Race race = Race.Human;
        public int hair = -1;
        public int head = 0;
        public Color cHair = default(Color);
        public Color cEye = default(Color);
        public Color cSkin = default(Color);
        public bool wet = false;
        public float lifeMod = 1f;

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemRace", (byte) race }, { "xahlicemHair", hair }, { "xahlicemCHair", cHair }, { "xahlicemCEye", cEye }, { "xahlicemCSkin", cSkin }, { "xahlicemLifeMod", lifeMod }
            };
        }

        public override void Load(TagCompound tag) {
            race = (Race) tag.GetByte("xahlicemRace");
            hair = tag.GetInt("xahlicemHair");
            cHair = tag.Get<Color>("xahlicemCHair");
            cEye = tag.Get<Color>("xahlicemCEye");
            cSkin = tag.Get<Color>("xahlicemCSkin");
            lifeMod = tag.GetFloat("xahlicemLifeMod");
        }

        /*public override void OnRespawn(Player player) {
            player.AddBuff(mod.BuffType<Buffs.Homeward>(), 60);
        }*/

        public override void ResetEffects() {
            wet = false;
        }

        public override void UpdateDead() {
            wet = false;
            lifeMod = 0.2f;
        }

        public override void PreUpdateBuffs() {
            wet = (player.FindBuffIndex(BuffID.Wet)) != -1 || player.wet;
            if (player.lavaWet || player.honeyWet) {
                wet = false;
                player.ClearBuff(BuffID.Wet);
            }
            if (Main.time % 60 == 0) {
                lifeMod += (player.FindBuffIndex(mod.BuffType<Buffs.Firelink>()) != -1) ? 0.1f : 0.002f;
                if (lifeMod > 1.5f) lifeMod = 1.5f;
            }
            player.statLifeMax2 = (int)(player.statLifeMax2 * lifeMod);

            switch (race) {
                case Race.Human:
                    if (hair != -1) player.hair = hair;
                    if (cHair != default(Color)) player.hairColor = cHair;
                    if (cEye != default(Color)) player.eyeColor = cEye;
                    if (cSkin != default(Color)) player.skinColor = cSkin;
                    head = 0;
                    break;
                case Race.Demon:
                    player.rangedDamage *= 0.8f;
                    player.magicDamage *= 1.25f;
                    player.manaCost *= 1.25f;
                    player.statLifeMax2 = (int)(player.statLifeMax2 * 0.8);

                    player.buffImmune[BuffID.OnFire] = true;
                    player.lavaRose = true;
                    player.fireWalk = true;
                    player.lavaMax = 600;
                    XahlicemPlayer p = player.GetModPlayer<XahlicemPlayer>();
                    if (Main.myPlayer == player.whoAmI && Main.time % 30 == 0 && p.wet) {
                        player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " couldn't stand the water."), 5, 0);
                    }

                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.Black;
                    player.skinColor = Color.DarkRed;
                    player.eyeColor = Color.Red;
                    head = 0;
                    break;

                case Race.Ant:
                    player.pickSpeed *= 0.75f;
                    player.maxRunSpeed += 1;
                    player.spikedBoots = 2;

                    player.hair = 15;
                    player.skinColor = new Color(75, 35, 15);
                    player.eyeColor = Color.Black;
                    head = 0;
                    break;

                case Race.Slime:
                    player.noFallDmg = true;
                    player.jumpSpeedBoost += 1;
                    player.jumpBoost = true;
                    player.slippy = true;
                    player.AddBuff(BuffID.Slimed, 10);

                    if (player.wet) {
                        player.gravity = -0.5f;
                    }

                    if (hair != -1) player.hair = hair;
                    player.hairColor = new Color(0, 50, 250, 50);
                    player.skinColor = new Color(100, 150, 255, 50);
                    player.eyeColor = new Color(0, 50, 250, 50);
                    head = 0;
                    break;
                case Race.Zombie:
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

                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(205, 255, 150);
                    player.eyeColor = Color.Red;
                    head = 0;
                    break;
                case Race.Goblin:
                    player.rangedDamage *= 1.25f;

                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.Gray;
                    player.skinColor = new Color(94, 152, 161);
                    player.eyeColor = Color.Red;
                    head = 217;
                    break;
                case Race.Skeleton:
                    player.ignoreWater = true;
                    player.breath = 100000;
                    player.lifeRegenCount = 0;

                    player.hair = 15;
                    player.skinColor = new Color(153, 153, 117);
                    player.eyeColor = Color.Black;
                    head = 93;
                    break;
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lifeMod -= (float)(damage / player.statLifeMax2) / 2.5f;
            if (lifeMod < 0.2f) lifeMod = 0.2f;
        }

        public override void FrameEffects() {
            if (head != 0)
                player.head = head;
            //player.face = headNum;
        }
        sbyte headNum = 0;
        public void DoStuff() {
            if (cEye == default(Color)) cEye = player.eyeColor;
            if (cSkin == default(Color)) cSkin = player.skinColor;
            if (cHair == default(Color)) cHair = player.hairColor;
            if (hair == -1) hair = player.hair;
            race = race.NextEnum();
            Main.NewText("Race = " + race, 255, 255, 255);
            headNum++;
            Main.NewText(head.ToString(), 255, 255, 255);
        }

        public void changeRace(Race r) {
            if (race != Race.Human) {
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " angered the gods by trying to interbreed!"), 10000, 0);
                return;
            }
            if (cEye == default(Color)) cEye = player.eyeColor;
            if (cSkin == default(Color)) cSkin = player.skinColor;
            if (cHair == default(Color)) cHair = player.hairColor;
            if (hair == -1) hair = player.hair;
            for (int i = 0; i < 150; i++) {
                Dust.NewDust(player.position, 8, 8, DustID.Blood, Main.rand.NextFloat() * 10 - 5, Main.rand.NextFloat() * 10 - 5);
            }
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " sheds their human flesh!"), 10000, 0);
            race = r;
        }
    }
}