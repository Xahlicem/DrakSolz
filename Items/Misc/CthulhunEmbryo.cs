using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CthulhunEmbryo : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cthulhun Embryo");
            Tooltip.SetDefault("Wriggling and writhing with malice Intent.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 6;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.CthulhunTentacle>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}