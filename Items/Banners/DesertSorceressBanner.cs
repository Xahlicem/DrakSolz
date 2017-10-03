using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Banners {
    public class DesertSorceressBanner : ModItem {
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
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType<Tiles.EnemyBanner>();
            item.placeStyle = 7; //Place style means which frame(Horizontally, starting from 0) of the tile should be placed
        }
    }
}