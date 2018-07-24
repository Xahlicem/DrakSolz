using Terraria;
using Terraria.ModLoader;
using DrakSolz.NPCs.Enemy.VoidPillar.Tiles;

namespace DrakSolz.NPCs.Enemy.VoidPillar.VoidItems
{
	public class VoidMonolith : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 32;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 10;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.createTile = mod.TileType<VoidMonolithTile>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Monolith");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "VoidFragment", 15);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}