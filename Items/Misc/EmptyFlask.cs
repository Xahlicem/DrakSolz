using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class EmptyFlask : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Empty Estus Flask");
            Tooltip.SetDefault("Refill at Firelink Shrines.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Yellow;
        }
    }
}