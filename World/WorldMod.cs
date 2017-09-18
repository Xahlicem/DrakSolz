using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace DrakSolz.Items.World {
    public class WorldMod : ModWorld {
        public const int CHEST_X_WOOD = 0 * 36;
        public const int CHEST_X_GOLD = 1 * 36;
        public const int CHEST_X_GOLD_LOCKED = 2 * 36;
        public const int CHEST_X_SHADOW = 3 * 36;
        public const int CHEST_X_SHADOW_LOCKED = 4 * 36;
        public const int CHEST_X_MAHOGANY = 8 * 36;
        public const int CHEST_X_IVY = 10 * 36;
        public const int CHEST_X_ICE = 11 * 36;
        public const int CHEST_X_LIVING = 12 * 36;
        public const int CHEST_X_SKY = 13 * 36;
        public const int CHEST_X_WEB = 15 * 36;
        public const int CHEST_X_LIHZ = 16 * 36;
        public const int CHEST_X_WATER = 17 * 36;
        public const int CHEST_X_MUSHROOM = 32 * 36;
        public const int CHEST_X_GRANITE = 50 * 36;
        public const int CHEST_X_MARBLE = 51 * 36;

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
            var LastIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            if (LastIndex != -1) {
                tasks.Insert(LastIndex, new PassLegacy("Drakening the World!", delegate(GenerationProgress progress) {
                    progress.Message = "Adding shinies";
                    progress.CurrentPassWeight = 1.0f;

                    foreach (Chest chest in Main.chest) {
                        if (chest == null) continue;
                        Tile tile = Main.tile[chest.x, chest.y];
                        if (tile.type == TileID.Containers && tile.frameX != CHEST_X_GOLD) continue;
                        if (Main.rand.Next(20) == 0) {
                            chest.item[0].SetDefaults(mod.ItemType<Items.Accessory.RingCat>());
                            chest.item[0].Prefix(-1);

                        }

                        for (int i = 0; i < chest.item.Length; i++) {
                            if (chest.item[i].type == ItemID.AquaScepter && Main.rand.Next(3) == 0) {
                                chest.item[i].SetDefaults(mod.ItemType<Items.Accessory.RingCat>());
                                chest.item[i].Prefix(-1);
                            }
                        }
                    }

                    for (int y = 0; y < Main.tile.GetLength(1); y++)
                        for (int x = 0; x < Main.tile.GetLength(0); x++) {
                            Tile t = Main.tile[x, y];
                            if (t == null) continue;
                            if (t.type == TileID.Campfire) {
                                //WorldGen.KillTile(x, y);
                                WorldGen.PlaceTile(x, y - 1, mod.TileType<Items.Misc.FirelinkShrineTile>());
                                //WorldGen.Place3x3(x, y, (ushort) mod.TileType<Items.Misc.FirelinkShrineTile>());

                            }
                        }
                }));
            }
        }

        public override void PostWorldGen() {
            NPC.NewNPC((int) Main.npc[0].position.X, (int) Main.npc[0].position.Y, mod.NPCType<NPCs.Town.Pilgrim>());
        }
    }
}