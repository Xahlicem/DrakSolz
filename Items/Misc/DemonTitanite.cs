using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class DemonTitanite : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Demon Titanite");
            Tooltip.SetDefault("From a fallen Titanite Demon.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
        }
    }
}