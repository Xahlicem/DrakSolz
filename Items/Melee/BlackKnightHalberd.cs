using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class BlackKnightHalberd : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Knight Halberd");
            Tooltip.SetDefault("A black knight's halberd; used for battle against demons.");
        }

        public override void SetDefaults() {
            item.damage = 1000;
            item.useStyle = 5;
            item.useAnimation = 26;
            item.useTime = 30;
            item.shootSpeed = 5.4f;
            item.knockBack = 4.5f;
            item.width = 28;
            item.height = 28;
            item.scale = 1f;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<Projectiles.BlackKnightHalberdProj>();
            item.value = Item.sellPrice(1, 50, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Banners.BlackKnightBanner>());
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}