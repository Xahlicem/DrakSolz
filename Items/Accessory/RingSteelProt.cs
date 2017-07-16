using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory
{
    public class RingSteelProt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ring of Steel Protection");
            Tooltip.SetDefault("This is a modded ring.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.defense = 5;
            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
         
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 500);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}