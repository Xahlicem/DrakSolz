using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged {
	public class GoldenSlingshot : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Golden Slingshot");
			Tooltip.SetDefault("Powerful weapon that launches small stones. Shooting like a pro!");
		}

		public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 0, 50);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 10.5f;
			item.useAmmo = (ModContent.ItemType<Items.Ranged.SlingshotStones>());
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddIngredient(ModContent.ItemType<Items.Ranged.ReinforcedSlingshot>(), 1);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}