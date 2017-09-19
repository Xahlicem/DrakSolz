using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class Scroll : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scroll of Sorcery");
            Tooltip.SetDefault("Used for writing down spells of sorcery.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 0;
        }
    }
}