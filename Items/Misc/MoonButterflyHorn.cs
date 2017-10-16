using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class MoonButterflyHorn : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Butterfly Horn");
            Tooltip.SetDefault("Twisted horn of a magical creature drawn to the moon's light.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 9;
        }
    }
}