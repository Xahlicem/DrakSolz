using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items {
    public class EaterBrainSummon : GlobalItem {

        public override void AddRecipes() {

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 1);
            recipe2.AddIngredient(ItemID.BloodySpine, 1);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.SetResult(ItemID.WormFood);
            recipe2.AddRecipe();

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 1);
            recipe.AddIngredient(ItemID.WormFood, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.BloodySpine);
            recipe.AddRecipe();
        }
    }
}