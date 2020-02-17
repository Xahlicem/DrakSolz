using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class TwinSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Entangled Soul");
            Tooltip.SetDefault("Soul of the Twins");
        }

        public TwinSoul() : base(30, 100000, "RingAvarice") { }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.RetSoul>());
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.SpazSoul>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(ModContent.ItemType<Items.Accessory.RingAvarice>());
            recipe.AddRecipe();
        }
    }
}