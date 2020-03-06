using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class Twink : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Twinkling Titanite");
            Tooltip.SetDefault("Rare titanite infused with crystalized magic.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Cyan;
        }
    }
}