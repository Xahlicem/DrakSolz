using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class PlantSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Verdant Soul");
            Tooltip.SetDefault("Soul of Plantera");
        }

        public PlantSoul() : base(11, 175000, "") { }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(mod.ItemType<Items.Accessory.RingMeleePower>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(mod.ItemType<Items.Accessory.RingMagicPower>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(mod.ItemType<Items.Accessory.RingRangePower>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(mod.ItemType<Items.Accessory.RingSummonPower>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(mod.ItemType<Items.Accessory.RingThrowingPower>());
            recipe.AddRecipe();
        }
    }
}