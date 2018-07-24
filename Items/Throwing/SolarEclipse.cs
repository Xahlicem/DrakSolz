using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Throwing {
    public class SolarEclipse : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Solar Eclipse");
            Tooltip.SetDefault("Miracle that projects a ring of Energy." +
                "\n Fires a more powerful ring at higher mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Terrarian);
            item.useStyle = 1;
            item.magic = false;
            item.damage = 130;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 30;
            item.useAnimation = 30;
            item.rare = 10;
            item.mana = 0;
            item.knockBack = 2.0f;
            item.shootSpeed = 12.0f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.WhiteCoronaProj1>();
            item.thrown = true;
        }
        
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "VoidFragment", 18);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}

        //public override void AddRecipes() {
        //ModRecipe recipe = new SoulRecipe(mod, this);
        //recipe.AddIngredient(mod.ItemType<Items.Misc.PyroScroll>());
        //recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
        //recipe.AddRecipe();
        //}

    }
}