using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Craft {
    public class Scroll : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scroll of Sorcery");
            Tooltip.SetDefault("Used for writing down spells of sorcery.");
        }

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 0;
        }
public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 1);
			recipe.AddIngredient(mod.ItemType("Soul"), 100);
            recipe.AddTile(mod.TileType<Items.Craft.FirelinkShrineTile>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}