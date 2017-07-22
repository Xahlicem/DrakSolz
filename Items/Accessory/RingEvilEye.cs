using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingEvilEye : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Evil Eye Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+Heals you when you kill an enemy");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.maxRunSpeed += 0.30f;
            player.meleeSpeed += 0.15f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 500);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}