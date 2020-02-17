using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace DrakSolz.Tiles {
    public class CorruptBanner : ModTile {
        public override void SetDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            dustType = -1;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            int style = frameX / 18;
            string item;
            switch (style) {
                case 0:
                    item = "DeepfireDevourerBanner";
                    break;
                case 1:
                    item = "CarrionCollectorBanner";
                    break;
                case 2:
                    item = "HexclawBanner";
                    break;
                case 3:
                    item = "DesolatorBanner";
                    break;
                case 4:
                    item = "SoulWraithBanner";
                    break;
                case 5:
                    item = "VorpalReaverBanner";
                    break;
                case 6:
                    item = "BlackSolusBanner";
                    break;
                case 7:
                    item = "GibbetBanner";
                    break;
                default:
                    return;
            }
            Item.NewItem(i * 16, j * 16, 16, 48, DrakSolz.instance.ItemType(item));
        }

        public override void NearbyEffects(int i, int j, bool closer) {
            if (closer) {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].frameX / 18;
                string type;
                switch (style) {
                    case 0:
                    type = "DeepfireDevourer";
                    break;
                case 1:
                    type = "CarrionCollector";
                    break;
                case 2:
                    type = "Hexclaw";
                    break;
                case 3:
                    type = "Desolator";
                    break;
                case 4:
                    type = "SoulWraith";
                    break;
                case 5:
                    type = "VorpalReaver";
                    break;
                case 6:
                    type = "BlackSolus";
                    break;
                case 7:
                    type = "Gibbet";
                    break;
                    default:
                        return;
                }
                player.NPCBannerBuff[DrakSolz.instance.NPCType(type)] = true;
                player.hasBanner = true;
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
            if (i % 2 == 1) {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
}