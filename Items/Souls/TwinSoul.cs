using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class TwinSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Entangled Soul");
            Tooltip.SetDefault("Soul of the Twins");
        }

        public TwinSoul() : base(30, 104) { }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Souls.RetSoul>());
            recipe.AddIngredient(mod.ItemType<Items.Souls.SpazSoul>());
            recipe.AddTile(mod.TileType<Items.Misc.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(mod.TileType<Items.Misc.FirelinkShrineTile>());
            recipe.SetResult(mod.ItemType<Items.Accessory.RingAvarice>());
            recipe.AddRecipe();
        }
    }
}