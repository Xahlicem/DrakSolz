using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace DrakSolz.Tiles {
    public class OverworldBanner : ModTile {
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
                    item = "DragonlarkBanner";
                    break;
                case 1:
                    item = "DustWailerBanner";
                    break;
                case 2:
                    item = "ShadowdancerBanner";
                    break;
                case 3:
                    item = "NightsorrowBanner";
                    break;
                case 4:
                    item = "VoidTalonBanner";
                    break;
                case 5:
                    item = "NightmareOperantBanner";
                    break;
                case 6:
                    item = "GhoulieBanner";
                    break;
                case 7:
                    item = "SilhouetteBanner";
                    break;
                case 8:
                    item = "NightWatcherBanner";
                    break;
                case 9:
                    item = "ReaperNineMoonsBanner";
                    break;
                case 10:
                    item = "BloodmoonAssassinBanner";
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
                    type = "Dragonlark";
                    break;
                case 1:
                    type = "DustWailer";
                    break;
                case 2:
                    type = "Shadowdancer";
                    break;
                case 3:
                    type = "Nightsorrow";
                    break;
                case 4:
                    type = "VoidTalon";
                    break;
                case 5:
                    type = "NightmareOperant";
                    break;
                case 6:
                    type = "Ghoulie";
                    break;
                case 7:
                    type = "Silhouette";
                    break;
                case 8:
                    type = "NightWatcher";
                    break;
                case 9:
                    type = "ReaperNineMoons";
                    break;
                case 10:
                    type = "BloodmoonAssassin";
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