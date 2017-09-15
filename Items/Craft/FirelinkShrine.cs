using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;

namespace DrakSolz.Items.Craft {
    public class FirelinkShrine : ModItem {
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Bonfire with a unique blade. A pleasent respite.");
    }

    public override void SetDefaults() {

        item.width = 46;
        item.height = 46;
        item.maxStack = 1;
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
        item.value = Item.buyPrice(0, 0, 0, 1);
        item.createTile = mod.TileType("FirelinkShrineTile");
    }
    public override void AddRecipes() {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(mod.ItemType<Items.Melee.SwordHilt>());
        recipe.AddIngredient(null, "HomewardBone", 5);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}

    public class FirelinkShrineTile : ModTile {
    public override void SetDefaults() {
        Main.tileLighted[Type] = true;
        //Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        //Main.tileTable[Type] = true;
        Main.tileLavaDeath[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.Width = 3;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
        TileObjectData.addTile(Type);

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

        ModTranslation name = CreateMapEntryName();
        name.SetDefault("Firelink Shrine");
        AddMapEntry(new Color(200, 200, 200), name);

        dustType = DustID.AmberBolt;
        disableSmartCursor = true;
        adjTiles = new int[] { TileID.WorkBenches, TileID.Beds, TileID.Campfire };
        bed = true;
        animationFrameHeight = 56;
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
        if (Main.tile[i, j].frameY >= 56) {
            r = 0.93f;
            g = 0.80f;
            b = 0.60f;
        }
    }

    public override void AnimateTile(ref int frame, ref int frameCounter) {
        frame = Main.tileFrame[TileID.Campfire];
        frameCounter = Main.tileFrameCounter[TileID.Campfire];
    }

    public override void NumDust(int i, int j, bool fail, ref int num) {
        num = fail ? 1 : 3;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY) {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("FirelinkShrine"));
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) {
        Tile tile = Main.tile[i, j];
        Texture2D texture;
        if (Main.canDrawColorTile(i, j)) {
            texture = Main.tileAltTexture[Type, (int) tile.color()];
        } else {
            texture = Main.tileTexture[Type];
        }
        Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        if (Main.drawToScreen) {
            zero = Vector2.Zero;
        }
        int animate = 0;
        if (tile.frameY >= 56) {
            animate = Main.tileFrame[Type] * animationFrameHeight;
        }
        Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int) Main.screenPosition.X, j * 16 - (int) Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY + animate, 16, 16), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 1f);
        return false;
    }

    public override void NearbyEffects(int i, int j, bool closer) {
        Player player = Main.LocalPlayer;
        if (closer && player.Distance(new Vector2(i << 4, j << 4)) < 50) {
            player.AddBuff(mod.BuffType<Buffs.Firelink>(), 30);
        }
    }

    public override void RightClick(int i, int j) {
        HitWire(i, j);
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[i, j];
        int spawnX = i - tile.frameX / 18 + 1;
        int spawnY = j;
        //spawnX += tile.frameX >= 72 ? 5 : 2;
        if (tile.frameY % 38 != 0) {
            spawnY--;
        }
        player.FindSpawn();
        if (player.SpawnX == spawnX && player.SpawnY == spawnY) {
            //player.RemoveSpawn();
            //Main.NewText("Spawn point removed!", 255, 240, 20, false);
        } else //if (Player.CheckSpawn(spawnX, spawnY))
        {
            player.RemoveSpawn();
            player.ChangeSpawn(spawnX, spawnY);
            Main.NewText((Player.CheckSpawn(spawnX, spawnY) ? "Permanent " : "Temporary ") + "spawn point set!", 255, 240, 20, false);
        }
    }

    public override void MouseOver(int i, int j) {
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.showItemIcon = true;
        player.showItemIcon2 = mod.ItemType("FirelinkShrine");
    }

    public override void HitWire(int i, int j) {
        int x = i - (Main.tile[i, j].frameX / 18) % 3;
        int y = j - (Main.tile[i, j].frameY / 18) % 3;
        for (int l = x; l < x + 3; l++) {
            for (int m = y; m < y + 3; m++) {
                if (Main.tile[l, m] == null) {
                    Main.tile[l, m] = new Tile();
                }
                if (Main.tile[l, m].active() && Main.tile[l, m].type == Type) {
                    if (Main.tile[l, m].frameY < 56) {
                        Main.tile[l, m].frameY += 56;
                    } else {
                        Main.tile[l, m].frameY -= 56;
                    }
                }
            }
        }
        if (Wiring.running) {
            Wiring.SkipWire(x, y);
            Wiring.SkipWire(x, y + 1);
            Wiring.SkipWire(x, y + 2);
            Wiring.SkipWire(x + 1, y);
            Wiring.SkipWire(x + 1, y + 1);
            Wiring.SkipWire(x + 1, y + 2);
            Wiring.SkipWire(x + 2, y);
            Wiring.SkipWire(x + 2, y + 1);
            Wiring.SkipWire(x + 2, y + 2);
        }
        NetMessage.SendTileSquare(-1, x, y + 1, 3);
    }
}

    /*public class ExampleStatueModWorld : ModWorld
    	{
    		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
    		{
    			int ResetIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Reset"));
    			if (ResetIndex != -1)
    			{
    				tasks.Insert(ResetIndex + 1, new PassLegacy("Kindling the Flame", delegate (GenerationProgress progress)
    				{
    					progress.Message = "Kindling the Flame";

    					// Not necessary, just a precaution.
    					if (WorldGen.statueList.Any(point => point.X == mod.TileType<FirelinkShrineTile>()))
    					{
    						return;
    					}
    					// Make space in the statueList array, and then add a Point16 of (TileID, PlaceStyle)
    					Array.Resize(ref WorldGen.statueList, WorldGen.statueList.Length + 1);
    					for (int i = 0; i < WorldGen.statueList.Length; i++)
    					{
                            
    						WorldGen.statueList[i] = new Point16(mod.TileType<FirelinkShrineTile>(), 0);
    						// Do this if you want the statue to spawn with wire and pressure plate
    						// WorldGen.StatuesWithTraps.Add(i);
    					}
    				}));
    			}
    		}
    	}*/
}