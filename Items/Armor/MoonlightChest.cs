using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items
{
    [AutoloadEquip(EquipType.Body)]
    public class MoonlightChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Moonlight Chestplate");
            Tooltip.SetDefault("Armor forged with pure moonlight."
                + "\n+20 Max Health"
                + "\n+20 Max Mana");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000000;
            item.rare = 9;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.statLifeMax2 += 20;
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
