using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class Lament : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lament");
            Tooltip.SetDefault("Edgy Sword.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.damage = 1000;
            item.knockBack = 7f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.scale *= 1.3f;
        }
        
                public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Titanite>(), 50);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}