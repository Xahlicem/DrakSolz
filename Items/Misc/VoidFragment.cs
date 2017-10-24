using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc
{
	public class VoidFragment : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 48;
			item.height = 48;
			item.value = 2000;
			item.rare = 9;
			item.maxStack = 999;

			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Fragment");
			Tooltip.SetDefault("'The absence of matter, a fragment of pure space'");
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(item.Center, new Vector3(0.5f, 0.5f, 0.5f) * Main.essScale);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(3459, 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}