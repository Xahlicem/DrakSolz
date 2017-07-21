using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Craft
{
	public class FirelinkShrine : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is a modded workbench.");
		}

		public override void SetDefaults()
		{

			item.width = 46;
			item.height = 46;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("FirelinkShrine2");
		}
public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Campfire);
			recipe.AddIngredient(null, "FirelinkShrine", 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}