using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items {
	public class MoonGS : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Moonlight Greatsword");
			Tooltip.SetDefault("Shoots a tiny eater!.");
		}
		public override void SetDefaults() {
            item.damage = 80;
            item.magic = true;
            item.mana = 18;
            item.width = 90;
            item.height = 90;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.noMelee = false; //so the item's animation doesn't do damage
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MGSProj");
            item.shootSpeed = 12f;
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
			return new Vector2(-50, -15);
		}
    }
}
