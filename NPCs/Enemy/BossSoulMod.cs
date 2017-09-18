using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DrakSolz.Items.Souls;

namespace DrakSolz.NPCs.Enemy {
    class BossSoulMod : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            int type = -1;
            int num = 0;
            switch (npc.type) {
                case NPCID.KingSlime:
                    type = mod.ItemType<Items.Souls.SlimeSoul>();
                    num = SlimeSoul.PLACE;
                    break;
                case NPCID.EyeofCthulhu:
                    type = mod.ItemType<Items.Souls.EyeSoul>();
                    num = EyeSoul.PLACE;
                    break;
                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                    if (!npc.boss) return;
                    type = mod.ItemType<Items.Souls.EaterSoul>();
                    num = EaterSoul.PLACE;
                    break;
                case NPCID.BrainofCthulhu:
                    type = mod.ItemType<Items.Souls.BrainSoul>();
                    num = BrainSoul.PLACE;
                    break;
                case NPCID.QueenBee:
                    type = mod.ItemType<Items.Souls.BeeSoul>();
                    num = BeeSoul.PLACE;
                    break;
                case NPCID.SkeletronHead:
                    type = mod.ItemType<Items.Souls.SkeletronSoul>();
                    num = SkeletronSoul.PLACE;
                    break;
                case NPCID.WallofFlesh:
                    type = mod.ItemType<Items.Souls.WallSoul>();
                    num = WallSoul.PLACE;
                    break;
                case NPCID.TheDestroyer:
                    type = mod.ItemType<Items.Souls.DestSoul>();
                    num = DestSoul.PLACE;
                    break;
                case NPCID.Retinazer:
                    type = mod.ItemType<Items.Souls.RetSoul>();
                    num = RetSoul.PLACE;
                    break;
                case NPCID.Spazmatism:
                    type = mod.ItemType<Items.Souls.SpazSoul>();
                    num = SpazSoul.PLACE;
                    break;
                case NPCID.SkeletronPrime:
                    type = mod.ItemType<Items.Souls.SkeletronPrimeSoul>();
                    num = SkeletronPrimeSoul.PLACE;
                    break;
                case NPCID.Plantera:
                    type = mod.ItemType<Items.Souls.PlantSoul>();
                    num = PlantSoul.PLACE;
                    break;
                case NPCID.Golem:
                    type = mod.ItemType<Items.Souls.GolemSoul>();
                    num = GolemSoul.PLACE;
                    break;
                case NPCID.CultistBoss:
                    type = mod.ItemType<Items.Souls.LunaticSoul>();
                    num = LunaticSoul.PLACE;
                    break;
                case NPCID.DukeFishron:
                    type = mod.ItemType<Items.Souls.DukeSoul>();
                    num = DukeSoul.PLACE;
                    break;
                case NPCID.MoonLordHand:
                    type = mod.ItemType<Items.Souls.MoonSoul>();
                    num = MoonSoul.PLACE;
                    break;
                case NPCID.MoonLordCore:
                case NPCID.MoonLordFreeEye:
                case NPCID.MoonLordHead:
                    if (!npc.boss) return;
                    type = mod.ItemType<Items.Souls.MoonSoul>();
                    num = MoonSoul.PLACE;
                    break;
            }

            if (npc.type == mod.NPCType<NPCs.Enemy.Abysswalker>()) {
                type = mod.ItemType<Items.Souls.ArtoriasSoul>();
                num = ArtoriasSoul.PLACE;
            }

            if (npc.type == mod.NPCType<NPCs.Enemy.TitaniteDemon>()) {
                type = mod.ItemType<Items.Souls.TitaniteSoul>();
                num = TitaniteSoul.PLACE;
            }

            if (type == -1) return;

            List<int> players = new List<int>();
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] != null)
                    if (npc.WithinRange(Main.player[i].Center, 800f))
                        players.Add(Main.player[i].whoAmI);
            if (players.Count != 0)
                for (int i = 0; i < players.Count; i++) {
                    if ((Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().BossSouls & num) > 0) continue;
                    int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, type);
                    Main.item[item].GetGlobalItem<Items.XItem>().FromPlayer = players[i];
                    Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().BossSouls |= num;
                }
        }
    }
}