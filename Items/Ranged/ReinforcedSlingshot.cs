using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged {
	public class ReinforcedSlingshot : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Reinforced Slingshot");
			Tooltip.SetDefault("Upgraded weapon that launches small stones. Shooting things has never been easier!");
		}

		public override void SetDefaults() {
			item.damage = 6;
			item.ranged = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 6.0f;
			item.useAmmo = (ModContent.ItemType<Items.Ranged.SlingshotStones>());
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddIngredient(ModContent.ItemType<Items.Ranged.Slingshot>(), 1);
			recipe.AddRecipeGroup("IronBar", 6);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}