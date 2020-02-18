using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Banners.OverworldBanners {
    public class NightWatcherBanner : ModItem {
        public override void SetDefaults() {
            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.createTile = ModContent.TileType<Tiles.OverworldBanner>();
            item.placeStyle = 8; //Place style means which frame(Horizontally, starting from 0) of the tile should be placed
        }
    }
}