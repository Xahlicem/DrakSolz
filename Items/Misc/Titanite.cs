using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class Titanite : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanite");
            Tooltip.SetDefault("Material used for crafting armor and weapons.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 5;
        }
    }
}