using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged
{
	public class SolpiercerBow : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Solpiercer Bow");
			Tooltip.SetDefault("Aim for the heart? No. We gotta go deeper" +
                "\nShoots Ichor Arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
            item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Arrow;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ExampleItem", 10);
			recipe.AddTile(null, "ExampleWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

		// What if I wanted this gun to have a 38% chance not to consume ammo?
		/*public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .38f;
		}*/

		// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
		// Uzi/Molten Fury style: Replace normal Bullets with Highvelocity

		// What if I wanted it to shoot like a shotgun?
		// Shotgun style: Multiple Projectiles, Random spread 
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}*/

		// What if I wanted an inaccurate gun? (Chain Gun)
		// Inaccurate Gun style: Single Projectile, Random spread 
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}*/

		// What if I wanted multiple projectiles in a even spread? (Vampire Knives) 
		// Even Arc style: Multiple Projectile, Even Spread 
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}*/

		// Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		// How can I make the shots appear out of the muzzle exactly?
		// Also, when I do this, how do I prevent shooting through tiles?
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = ProjectileID.IchorArrow;
			return true;
		}
                public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.WallSoul>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}