using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Craft {
    public class PyroScroll : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scroll of Pyromancy");
            Tooltip.SetDefault("Used for writing down techniques of pyromancy.");
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
            recipe.AddTile(mod.TileType("FirelinkShrine2"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}