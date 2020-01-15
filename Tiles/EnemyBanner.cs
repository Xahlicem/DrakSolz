using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace DrakSolz.Tiles {
    public class EnemyBanner : ModTile {
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
                    item = "NinjaBanner";
                    break;
                case 1:
                    item = "WheelSkeletonBanner";
                    break;
                case 2:
                    item = "ChannelerBanner";
                    break;
                case 3:
                    item = "CrystalLizardBanner";
                    break;
                case 4:
                    item = "FlameWarmageBanner";
                    break;
                case 5:
                    item = "RavelordBanner";
                    break;
                case 6:
                    item = "SpinwheelBanner";
                    break;
                case 7:
                    item = "DesertSorceressBanner";
                    break;
                case 8:
                    item = "PursuerBanner";
                    break;
                case 9:
                    item = "HumanityBanner";
                    break;
                case 10:
                    item = "GiantCrystalLizardBanner";
                    break;
                case 11:
                    item = "DragonSlayerBanner";
                    break;
                case 12:
                    item = "ManEaterShellBanner";
                    break;
                case 13:
                    item = "LittleMushroomBanner";
                    break;
                case 14:
                    item = "MoonButterflyBanner";
                    break;
                case 15:
                    item = "SilverKnightBanner";
                    break;
                case 16:
                    item = "BlackKnightBanner";
                    break;
                case 17:
                    item = "InhumanityBanner";
                    break;
                case 18:
                    item = "NightMareBanner";
                    break;
                case 19:
                    item = "VoidEaterBanner";
                    break;
                case 20:
                    item = "VoidWalkerBanner";
                    break;
                case 21:
                    item = "VoidlingBanner";
                    break;
                case 22:
                    item = "RingedKnightBanner";
                    break;
                case 23:
                    item = "HollowDogBanner";
                    break;
                case 24:
                    item = "ChickenBanner";
                    break;
                case 25:
                    item = "HollowBanner";
                    break;
                case 26:
                    item = "CthulhunBanner";
                    break;
                default:
                    return;
            }
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
        }

        public override void NearbyEffects(int i, int j, bool closer) {
            if (closer) {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].frameX / 18;
                string type;
                switch (style) {
                    case 0:
                        type = "Ninja";
                        break;
                    case 1:
                        type = "WheelSkeleton";
                        break;
                    case 2:
                        type = "Channeler";
                        break;
                    case 3:
                        type = "CrystalLizard";
                        break;
                    case 4:
                        type = "FlameWarmage";
                        break;
                    case 5:
                        type = "Ravelord";
                        break;
                    case 6:
                        type = "Spinwheel";
                        break;
                    case 7:
                        type = "DesertSorceress";
                        break;
                    case 8:
                        type = "ThePursuer";
                        break;
                    case 9:
                        type = "Humanity";
                        break;
                    case 10:
                        type = "GiantCrystalLizard";
                        break;
                    case 11:
                        type = "DragonSlayer";
                        break;
                    case 12:
                        type = "ManEaterShell";
                        break;
                    case 13:
                        type = "LittleMushroom";
                        break;
                    case 14:
                        type = "MoonButterfly";
                        break;
                    case 15:
                        type = "SilverKnight";
                        break;
                    case 16:
                        type = "BlackKnight";
                        break;
                    case 17:
                        type = "Inhumanity";
                        break;
                    case 18:
                        type = "NightMare";
                        break;
                    case 19:
                        type = "VoidEater";
                        break;
                    case 20:
                        type = "VoidWalker";
                        break;
                    case 21:
                        type = "Voidling";
                        break;
                    case 22:
                        type = "RingedKnight";
                        break;
                    case 23:
                        type = "HollowDog";
                        break;
                    case 24:
                        type = "Chicken";
                        break;
                    case 25:
                        type = "Hollow";
                        break;
                    case 26:
                        type = "Cthulhun";
                        break;
                    default:
                        return;
                }
                player.NPCBannerBuff[mod.NPCType(type)] = true;
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