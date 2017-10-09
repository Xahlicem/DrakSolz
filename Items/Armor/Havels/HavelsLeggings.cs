using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Havels {
    [AutoloadEquip(EquipType.Legs)]
    public class HavelsLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Habel's Leggings");
            Tooltip.SetDefault("Apparel worn by Habel the Rock.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 0;
            item.defense = 35;
        }

        public override void UpdateEquip(Player player) {
            player.fireWalk = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}