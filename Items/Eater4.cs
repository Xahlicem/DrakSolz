using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items {
	public class Eater4 : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eater of Chaos");
			Tooltip.SetDefault("Shoots flaming tiny eaters!.");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.BeeGun);
			item.damage = 32;
            item.shoot = mod.ProjectileType("EaterProj");
            item.mana = 15;
			item.knockBack = 1f;
            item.shootSpeed = 5.5f;

		}

        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Eater3"), 1);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.CursedFlame, 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Eater3"), 1);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
		public override Vector2? HoldoutOffset() {
			return new Vector2(-5, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2; 
			numberProjectiles += Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].ai[1] = 3;
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
    }
}
