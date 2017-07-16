using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory
{
    public class RingCharred : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ring");
            Tooltip.SetDefault("This is a modded ring."
                + "\n+Immunity to Fire"
                + "\n+Inflict Fire on hit");
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
            player.lavaRose = true;
            player.fireWalk = true;
            player.AddBuff(BuffID.WeaponImbueFire, 2);
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