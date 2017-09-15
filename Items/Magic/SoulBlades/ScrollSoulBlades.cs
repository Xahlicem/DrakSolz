using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.SoulBlades {
    public class ScrollSoulBlades : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Blades");
            Tooltip.SetDefault("Sorcery that projects blades from above toward your target.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 28;
            item.useTime = 22;
            item.useAnimation = 22;
            item.shoot = mod.ProjectileType("SorcSwordProj");
            item.mana = 5;
            item.knockBack = 3f;
            item.shootSpeed = 25.0f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 2000);
            recipe.AddIngredient(mod.ItemType<Items.Craft.Scroll>());
            recipe.AddTile(mod.TileType<Items.Craft.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
            /*recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();*/
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y - 50, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}