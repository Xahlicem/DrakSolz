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
        public bool falling = false;
        public float lifeMod = 1f;

        public override TagCompound Save() {
            return new TagCompound { { "xahlicemRace", (byte) race }, { "xahlicemHead", head }, { "xahlicemHair", hair }, { "xahlicemCHair", cHair }, { "xahlicemCEye", cEye }, { "xahlicemCSkin", cSkin }, { "xahlicemLifeMod", lifeMod }
            };
        }

        public override void Load(TagCompound tag) {
            race = (Race) tag.GetByte("xahlicemRace");
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

            if (race != Race.Human) player.AddBuff(mod.BuffType(race.ToString()), 10);
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            if (race == Race.Slime && damageSource.SourceNPCIndex >= 0)
                if (Main.npc[damageSource.SourceNPCIndex].FullName.Contains("Slime")) {
                    if (damage <= player.statDefense) return false;
                }
            return true;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            lifeMod -= (float)(damage / player.statLifeMax2) / 2.5f;
            if (lifeMod < 0.2f) lifeMod = 0.2f;
        }

        public override void FrameEffects() {
            if (head != 0)
                player.head = (head == 93) ? head : mod.GetItem(race.ToString() + "Head").item.headSlot;

            if (falling) player.wingFrame = 2;
        }
        //int num = 0;
        public void DoStuff() {
            if (cEye == default(Color)) cEye = player.eyeColor;
            if (cSkin == default(Color)) cSkin = player.skinColor;
            if (cHair == default(Color)) cHair = player.hairColor;
            if (hair == -1) hair = player.hair;
            ChangeRace(race.NextEnum(), true);
            Main.NewText("Race = " + race, 255, 255, 255);
            //num++;
            //Main.NewText(num.ToString(), 255, 255, 255);
        }

        public override void SetupStartInventory(IList<Item> items) {
            Item item = new Item();
            item.SetDefaults(mod.ItemType<Items.Misc.SoulVessel>());
            item.stack = 1;
            items.Add(item);
        }

        public override void ProcessTriggers(TriggersSet triggersSet) {
            falling = (!player.justJumped && triggersSet.Jump && player.velocity.Y >= 0.01f);
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
                    break;
                case Race.Ant:
                    player.hair = 15;
                    player.skinColor = new Color(75, 35, 15);
                    player.eyeColor = Color.Black;
                    head = 0;
                    break;
                case Race.Slime:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = new Color(0, 50, 250, 50);
                    player.skinColor = new Color(100, 150, 255, 50);
                    player.eyeColor = new Color(0, 50, 250, 50);
                    head = 0;
                    break;
                case Race.Zombie:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(205, 255, 150);
                    player.eyeColor = Color.Red;
                    head = 0;
                    break;
                case Race.Goblin:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.Gray;
                    player.skinColor = new Color(94, 152, 161);
                    player.eyeColor = Color.Red;
                    head = 1;
                    break;
                case Race.Skeleton:
                    player.hair = 15;
                    player.skinColor = new Color(153, 153, 117);
                    player.eyeColor = Color.Black;
                    head = 93;
                    break;
                case Race.Lizardman:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(75, 135, 50);
                    player.eyeColor = Color.Red;
                    head = 1;
                    break;
                case Race.Shade:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.Black;
                    player.skinColor = new Color(0, 0, 0);
                    player.eyeColor = Color.White;
                    head = 1;
                    break;
                case Race.Robot:
                    if (hair != -1) player.hair = hair;
                    player.hairColor = Color.DarkGray;
                    player.skinColor = new Color(120, 120, 120);
                    player.eyeColor = Color.Green;
                    head = 1;
                    break;
            }
        }
    }
}