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
            Skeleton,
            Lizardman,
            Shade,
            Robot
        }
        public Race race = Race.Human;
        private int raceBuff = -1;
        public int hair = -1;
        public int head = 0;
        public Color cHair = default(Color);
        public Color cEye = default(Color);
        public Color cSkin = default(Color);
        public bool wet = false;
        public float lifeMod = 1f;

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemRace", (byte) race }, { "xahlicemRaceBuff", raceBuff }, { "xahlicemHead", head }, { "xahlicemHair", hair }, { "xahlicemCHair", cHair }, { "xahlicemCEye", cEye }, { "xahlicemCSkin", cSkin }, { "xahlicemLifeMod", lifeMod }
            };
        }

        public override void Load(TagCompound tag) {
            race = (Race) tag.GetByte("xahlicemRace");
            raceBuff = tag.GetInt("xahlicemRaceBuff");
            hair = tag.GetInt("xahlicemHair");
            head = tag.GetInt("xahlicemHead");
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
            if (player.statLife < 0) player.statLife = 0;
            if (player.statMana < 0) player.statMana = 0;

            if (raceBuff != -1) player.AddBuff(raceBuff, 10);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lifeMod -= (float)(damage / player.statLifeMax2) / 2.5f;
            if (lifeMod < 0.2f) lifeMod = 0.2f;
        }

        public override void FrameEffects() {
            if (head != 0)
                player.head = head;
            //player.head = headNum;
        }
        int headNum = 217;
        public void DoStuff() {
            if (cEye == default(Color)) cEye = player.eyeColor;
            if (cSkin == default(Color)) cSkin = player.skinColor;
            if (cHair == default(Color)) cHair = player.hairColor;
            if (hair == -1) hair = player.hair;
            ChangeRace(race.NextEnum(), true);
            Main.NewText("Race = " + race, 255, 255, 255);
            headNum++;
            Main.NewText(headNum.ToString(), 255, 255, 255);
        }

        public void ChangeRace(Race r, bool force = false) {
            if (race != Race.Human && !force) {
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
            if (!force) player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " sheds their human flesh!"), 10000, 0);
            race = r;

            switch (race) {
                case Race.Human:
                    if (hair != -1) player.hair = hair;
                    if (cHair != default(Color)) player.hairColor = cHair;
                    if (cEye != default(Color)) player.eyeColor = cEye;
                    if (cSkin != default(Color)) player.skinColor = cSkin;
                    head = 0;
                    raceBuff = -1;
                    break;
                case Race.Demon:
                    player.hairColor = Color.Black;
                    player.skinColor = Color.DarkRed;
                    player.eyeColor = Color.Red;
                    head = 0;
                    raceBuff = mod.BuffType<Buffs.Race.Demon>();
                    break;
                case Race.Ant:
                    player.hair = 15;
                    player.skinColor = new Color(75, 35, 15);
                    player.eyeColor = Color.Black;
                    head = 0;
                    raceBuff = mod.BuffType<Buffs.Race.Ant>();
                    break;
                case Race.Slime:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = new Color(0, 50, 250, 50);
                    player.skinColor = new Color(100, 150, 255, 50);
                    player.eyeColor = new Color(0, 50, 250, 50);
                    head = 0;
                    raceBuff = mod.BuffType<Buffs.Race.Slime>();
                    break;
                case Race.Zombie:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(205, 255, 150);
                    player.eyeColor = Color.Red;
                    head = 0;
                    raceBuff = mod.BuffType<Buffs.Race.Zombie>();
                    break;
                case Race.Goblin:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.Gray;
                    player.skinColor = new Color(94, 152, 161);
                    player.eyeColor = Color.Red;
                    head = 217;
                    raceBuff = mod.BuffType<Buffs.Race.Goblin>();
                    break;
                case Race.Skeleton:
                    player.hair = 15;
                    player.skinColor = new Color(153, 153, 117);
                    player.eyeColor = Color.Black;
                    head = 93;
                    raceBuff = mod.BuffType<Buffs.Race.Skeleton>();
                    break;
                case Race.Lizardman:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(75, 135, 50);
                    player.eyeColor = Color.Red;
                    head = 218;
                    raceBuff = mod.BuffType<Buffs.Race.LizardMan>();
                    break;
                case Race.Shade:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.Black;
                    player.skinColor = new Color(0, 0, 0);
                    player.eyeColor = Color.White;
                    head = 221;
                    raceBuff = mod.BuffType<Buffs.Race.Shade>();
                    break;
                case Race.Robot:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(120, 120, 120);
                    player.eyeColor = Color.Green;
                    head = 220;
                    raceBuff = mod.BuffType<Buffs.Race.Robot>();
                    break;
            }
        }
    }
}