using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollBlackFireball : PyromancyItem {
        public PyroScrollBlackFireball() : base(55000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Fireball");
            Tooltip.SetDefault("Pyromancy that projects a black Fireball toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 68;
            item.useTime = 28;
            item.useAnimation = 28;
            item.mana = 15;
			item.crit = 4;
            item.knockBack = 7f;
            item.shootSpeed = 10.0f;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.BlackFireballProj>();
        }

        public override void AddRecipes() {
            ModRecipe recipe = new PyromancyRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireBall>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
                position += muzzleOffset;
            }

            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            return false;
        }
    }
}