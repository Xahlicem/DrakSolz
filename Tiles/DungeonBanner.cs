using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace DrakSolz.Tiles {
    public class DungeonBanner : ModTile {
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
                    item = "SwordofAkraneBanner";
                    break;
                case 1:
                    item = "WhiteWidowBanner";
                    break;
                case 2:
                    item = "ShinkageBanner";
                    break;
                case 3:
                    item = "HighTemplarBanner";
                    break;
                case 4:
                    item = "BladeseekerBanner";
                    break;
                case 5:
                    item = "HereticBanner";
                    break;
                case 6:
                    item = "RejuvenatorBanner";
                    break;
                case 7:
                    item = "VigilantBanner";
                    break;
                case 8:
                    item = "VerdantBanner";
                    break;
                case 9:
                    item = "InfernalBanner";
                    break;
                case 10:
                    item = "FrigidBanner";
                    break;
                case 11:
                    item = "DivineBanner";
                    break;
                case 12:
                    item = "DemonicBanner";
                    break;
                case 13:
                    item = "AridBanner";
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
                        type = "SwordofAkrane";
                        break;
                    case 1:
                        type = "WhiteWidow";
                        break;
                    case 2:
                        type = "Shinkage";
                        break;
                    case 3:
                        type = "HighTemplar";
                        break;
                    case 4:
                        type = "Bladeseeker";
                        break;
                    case 5:
                        type = "Heretic";
                        break;
                    case 6:
                        type = "Rejuvenator";
                        break;
                    case 7:
                        type = "VigilantSister";
                        break;
                    case 8:
                        type = "VerdantSister";
                        break;
                    case 9:
                        type = "InfernalSister";
                        break;
                    case 10:
                        type = "FrigidSister";
                        break;
                    case 11:
                        type = "DivineSister";
                        break;
                    case 12:
                        type = "DemonicSister";
                        break;
                    case 13:
                        type = "AridSister";
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