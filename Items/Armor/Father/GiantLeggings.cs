using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Father {
    [AutoloadEquip(EquipType.Legs)]
    public class GiantLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Giant's Leggings");
            Tooltip.SetDefault("Giants! Giants! Giants!");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 30;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 35);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 35);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}