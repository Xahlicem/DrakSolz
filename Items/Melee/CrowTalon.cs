using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class CrowTalon : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Krow Talon");
            Tooltip.SetDefault("Talons used by Korvian Knights.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BladedGlove);
            item.damage = 100;
            item.crit = 8;
            item.knockBack = 5f;
            item.useTime = 7;
            item.useAnimation = 7;
            item.scale *= 0.5f;
            item.value = Item.sellPrice(0, 25, 0, 0);
        }
        
                public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 1);
            recipe.AddIngredient(ItemID.FetidBaghnakhs, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}