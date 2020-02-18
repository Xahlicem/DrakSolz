using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollFireBall : SoulItem {
        public PyroScrollFireBall() : base(1000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Ball");
            Tooltip.SetDefault("Pyromancy that projects a Fire Ball toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 10;
            item.knockBack = 4f;
            item.shootSpeed = 3.0f;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.shoot = 376;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.PyroScroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            return false;
        }
    }
}