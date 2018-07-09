using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolyForce : SoulItem {
        public ScrollHolyForce() : base(100) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Force");
            Tooltip.SetDefault("Pyromancy that projects a Fire Ball toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 6;
            item.useTime = 40;
            item.useAnimation = 40;
            item.mana = 5;
            item.knockBack = 12f;
            item.shootSpeed = 3.0f;
            item.shoot = mod.ProjectileType<Projectiles.ForceProj>();
        }


        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.ScrollHoly>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            return false;
        }
    }
}