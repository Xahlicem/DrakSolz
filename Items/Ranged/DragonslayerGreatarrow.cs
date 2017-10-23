using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged
{
	public class DragonslayerGreatarrow : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dragonslayer Greatarrow");
			Tooltip.SetDefault("Large metal arrows used to penetrate the flesh of dragons.");
		}

		public override void SetDefaults()
		{
			item.damage = 120;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 8f;
			item.value = 100;
			item.rare = 2;
			item.shoot = mod.ProjectileType("DragonslayerGreatarrowProj");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = (mod.ItemType<Items.Ranged.DragonslayerGreatarrow>());              //The ammo class this ammo belongs to.
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddIngredient(null, "ExampleItem", 1);
			recipe.AddTile(null, "ExampleWorkbench");
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}*/
	}
}