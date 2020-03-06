using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged {
	public class Moltenshot : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Moltenshot");
			Tooltip.SetDefault("Slingshot imbued with fire. Shoot flaming balls at your enemies!");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.ranged = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 6.0f;
			item.useAmmo = (ModContent.ItemType<Items.Ranged.SlingshotStones>());
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (type == ModContent.ProjectileType<Projectiles.SlingshotStonesProj>()) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.ImpFireball; // or ProjectileID.FireArrow;
			}
			if (type == ProjectileID.SpikyBall) {
				type = ModContent.ProjectileType<Projectiles.SlingshotMoltenSpikyProj>();
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddIngredient(ModContent.ItemType<Items.Ranged.GoldenSlingshot>(), 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}