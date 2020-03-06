using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged {
	public class Slingshot : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slingshot");
			Tooltip.SetDefault("Sturdy wooden weapon that launches small stones. A beginners introduction to shooting things.");
		}

		public override void SetDefaults() {
			item.damage = 2;
			item.ranged = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 2.5f;
			item.useAmmo = (ModContent.ItemType<Items.Ranged.SlingshotStones>());
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipeGroup("Wood", 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}