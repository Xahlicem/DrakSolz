using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollBurstingFireBall : SoulItem {
        public PyroScrollBurstingFireBall() : base(15000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bursting Fire Ball");
            Tooltip.SetDefault("Pyromancy that projects a Fire Ball toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 42;
            item.useTime = 25;
            item.useAnimation = 25;
            item.mana = 10;
            item.knockBack = 4f;
			item.crit = 4;
            item.shootSpeed = 5.0f;
            item.shoot = 376;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.autoReuse = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireBall>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}