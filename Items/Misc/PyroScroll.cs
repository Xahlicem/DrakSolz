using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class PyroScroll : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scroll of Pyromancy");
            Tooltip.SetDefault("Used for writing down techniques of pyromancy.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.White;
        }
    }
}