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
                    NPC.NewNPC((int) Main.npc[0].position.X, (int) Main.npc[0].position.Y, mod.NPCType<NPCs.Town.Pilgrim>());
                    progress.Message = "Adding shinies";
                    progress.CurrentPassWeight = Main.chest.Length;

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
                        progress.Value++;
                    }
                }));
            }
            int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            if (LivingTreesIndex != -1) {
                tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", delegate(GenerationProgress progress) {
                    progress.Message = "Linking the Fire";
                    MakeRoom(progress);
                }));
            }
        }

        private void MakeRoom(GenerationProgress progress) {
            float widthScale = (Main.maxTilesX / 2100f);
            int numberToGenerate = WorldGen.genRand.Next(1, (int)(2f * widthScale));
            progress.CurrentPassWeight = numberToGenerate;
            for (int k = 0; k < numberToGenerate; k++) {
                bool success = false;
                int attempts = 0;
                while (!success) {
                    attempts++;
                    if (attempts > 1000) {
                        success = true;
                        continue;
                    }
                    int width = WorldGen.genRand.Next(0, 30);
                    int height = WorldGen.genRand.Next(0, 30);
                    int i = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
                    if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50) {
                        int j = WorldGen.genRand.Next((int) Main.worldSurface + 100, (int) Main.worldSurface + 600);
                        bool placementOK = true;
                        for (int l = i - width; l < i + width; l++) {
                            for (int m = j; m < j + height; m++) {
                                if (Main.tile[l, m].active()) {
                                    int type = (int) Main.tile[l, m].type;
                                    if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud) {
                                        placementOK = false;
                                    }
                                }
                            }
                        }
                        if (placementOK) {
                            success = WorldGen.genRand.NextBool() ? PlaceRoomSide(i, j, width, height, WorldGen.genRand.NextBool()) : PlaceRoomUp(i, j, width, height);
                        }
                    }
                }

                progress.Value++;
            }
        }

        public bool PlaceRoomUp(int x, int y, int width, int height) {
            if (Main.tile[x, y - 1].active() || Main.tile[x + 1, y - 1].active() || Main.tile[x - 1, y - 1].active()) return false;
            if (y < 150 || width < 4 || height < 7) return false;

            PlaceRoom(x, y, width, height);

            for (int i = -1; i <= 1; i++) place(x + i, y, false, false);
            place(x - 2, y + 2, true);
            place(x + 2, y + 2, true);
            place(x - 2, y + 1, true);
            place(x + 2, y + 1, true);
            place(x - 3, y + 1, true);
            place(x + 3, y + 1, true);

            return true;
        }

        public bool PlaceRoomSide(int x, int y, int width, int height, bool right) {
            if (Main.tile[x + (right?width + 1: -width - 1), y + height - 1].active() || Main.tile[x + (right?width + 1: -width - 1), y + height - 2].active() || Main.tile[x + (right?width + 1: -width - 1), y + height - 3].active()) return false;
            if (y < 150 || width < 4 || height < 7) return false;

            PlaceRoom(x, y, width, height);

            for (int i = 1; i <= 3; i++) place((right?x + width : x - width), y + height - i, false, false);
            place((right?x + width - 1 : x - width + 1), y + height - 4);
            place((right?x + width - 2 : x - width + 2), y + height - 4);
            place((right?x + width - 1 : x - width + 1), y + height - 5);
            return true;
        }

        private void PlaceRoom(int x, int y, int width, int height) {
            for (int y2 = 0; y2 <= height; y2++) {
                for (int x2 = -width; x2 <= width; x2++) {
                    int k = x + x2;
                    int l = y + y2;
                    if (WorldGen.InWorld(k, l, 30)) {
                        if (x2 == -width || x2 == width || y2 == 0 || y2 == height) {
                            place(k, l);
                        } else place(k, l, true, false);

                    }
                }
            }

            int candle = height - 6;
            while (candle > 2) {
                WorldGen.PlaceTile(x - width + 1, y + candle, TileID.Platforms, false, false, -1, 5);
                WorldGen.PlaceTile(x - width + 1, y + candle - 1, TileID.WaterCandle);
                WorldGen.PlaceTile(x + width - 1, y + candle, TileID.Platforms, false, false, -1, 5);
                WorldGen.PlaceTile(x + width - 1, y + candle - 1, TileID.WaterCandle);
                candle -= 6;
            }

            bool placeSuccessful = false;
            Tile t;
            int tileToPlace = mod.TileType<Tiles.FirelinkShrineTile>();
            while (!placeSuccessful) {
                int x2 = WorldGen.genRand.Next(-width + 1, width - 1) + x;
                int y2 = WorldGen.genRand.Next(1, height) + y;
                WorldGen.PlaceTile(x2, y2, tileToPlace);
                t = Main.tile[x2, y2];
                placeSuccessful = t.active() && t.type == tileToPlace;
            }
        }

        private void place(int x, int y, bool wall = false, bool active = true) {
            Tile tile = Framing.GetTileSafely(x, y);
            tile.type = TileID.BlueDungeonBrick;
            tile.active(active);
            tile.liquid = 0;
            if (wall) tile.wall = WallID.BlueDungeon;
        }

        public override void PostWorldGen() { }
    }
}