using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.SoulArrow {
    public class ScrollSoulDart : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Dart");
            Tooltip.SetDefault("Sorcery that projects a soul dart toward your target.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 8;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("SoulDartProj");
            item.mana = 3;
            item.knockBack = 1f;
            item.shootSpeed = 25.0f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 100);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(mod.TileType("FirelinkShrine2"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            /*recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();*/
        }

        //public override Vector2? HoldoutOffset() {
            //return new Vector2(-5, 0);
        //}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}