using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items {
	public class MorianBlade : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Morian Blade");
			Tooltip.SetDefault("Thrives off of its wielder's mortality.");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.BreakerBlade);
			item.damage = 40;
			item.knockBack = 6f;
            item.useTime = 2;
            item.useAnimation = 25;
        }

        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk, 15);
            recipe.AddIngredient(ItemID.VilePowder, 30);
            recipe.AddIngredient(ItemID.WormTooth, 10);
            recipe.AddIngredient(ItemID.Emerald, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, 0);
		}

        public override bool UseItem(Player player)
        {
            item.damage = 30 + (int) ((player.statLifeMax - player.statLife) * 0.1f);
            return base.UseItem(player);
        }
    }
}
