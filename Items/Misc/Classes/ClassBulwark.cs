using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc.Classes {
    public class ClassBulwark : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bulwark Rune");
            Tooltip.SetDefault("Consume to focus on vitality and defense.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Pho);
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 1;
            item.maxStack = 1;
            item.consumable = true;
        }
        public override bool UseItem(Player player) {
            Main.NewText("A Bulwark has been chosen!", 255, 150, 0);
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);
            modPlayer.ClassBulwark = true;
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Classes.ClassEmpty>(), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}