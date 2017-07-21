using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace XahlicemMod.Items.Craft {
    public class FirelinkShrine2 : ModTile {
        public override void SetDefaults() {
            Main.tileLighted[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
			
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Example Workbench");
            AddMapEntry(new Color(200, 200, 200), name);
            dustType = DustID.AmberBolt;
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.WorkBenches };
            animationFrameHeight = 54;
        }

        int animationFrameWidth = 54;
        bool on = true;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
            r = 0.93f;
            g = 0.11f;
            b = 0.12f;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter) {
            /*frameCounter++;
            if (frameCounter > Main.rand.NextFloat() * 10) {
                frameCounter = 0;
                frame++;
                if (frame > 8) {
                    frame = 1;
                }
            }*/
            frame = Main.tileFrame[TileID.Campfire];
            frameCounter = Main.tileFrameCounter[TileID.Campfire];
            //if (!on) frame = 0;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("FirelinkShrine"));
        }

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Texture2D texture;
			if (Main.canDrawColorTile(i, j))
			{
				texture = Main.tileAltTexture[Type, (int)tile.color()];
			}
			else
			{
				texture = Main.tileTexture[Type];
			}
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int animate = 0;
			if (tile.frameY >= 54)
			{
				animate = Main.tileFrame[Type] * animationFrameHeight;
			}
			Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY + animate, 16, 16), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 1f);
			//Main.spriteBatch.Draw(mod.GetTexture("Tiles/VoidMonolith_Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY + animate, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			return false;
		}

        public override void RightClick(int i, int j) {
            HitWire(i, j);
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
            for (int l = x; l < x + 2; l++) {
                for (int m = y; m < y + 3; m++) {
                    if (Main.tile[l, m] == null) {
                        Main.tile[l, m] = new Tile();
                    }
                    if (Main.tile[l, m].active() && Main.tile[l, m].type == Type) {
                        if (Main.tile[l, m].frameY < 54) {
                            Main.tile[l, m].frameY += 54;
                        } else {
                            Main.tile[l, m].frameY -= 54;
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
            }
            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }
    }
}