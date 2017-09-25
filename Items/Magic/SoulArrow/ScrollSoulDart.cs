using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.SoulArrow {
    public class ScrollSoulDart : SoulItem {
        public ScrollSoulDart() : base(50) { }

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
            item.mana = 2;
            item.knockBack = 1f;
            item.shootSpeed = 25.0f;
            item.shoot = mod.ProjectileType<Projectiles.Magic.SoulProj>();
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Scroll>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 0;
            return false;
        }
    }
}