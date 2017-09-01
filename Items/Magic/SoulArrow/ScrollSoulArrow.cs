using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace XahlicemMod.Items.Magic.SoulArrow {
    public class ScrollSoulArrow : SoulItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Arrow");
            Tooltip.SetDefault("Sorcery that projects a soul arrow toward your target.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 17;
            item.useTime = 30;
            item.useAnimation = 30;
            item.shoot = mod.ProjectileType("SoulArrowProj");
            item.mana = 5;
            item.knockBack = 2f;
            item.shootSpeed = 20.0f;
            SoulValue = 500;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Craft.Scroll>());
            recipe.AddTile(mod.TileType<Items.Craft.FirelinkShrineTile>());
            recipe.AddRecipe();
            recipe = new SoulRecipe(mod, this);
            recipe.AddRecipe();
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