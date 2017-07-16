using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory
{
    public class RingThrowingPower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thief's Ring");
            Tooltip.SetDefault("This is a modded ring."
                + "\n+20% Throwing Damage");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.20f;
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