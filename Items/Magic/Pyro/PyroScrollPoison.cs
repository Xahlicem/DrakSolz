using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollPoison : SoulItem {
        public PyroScrollPoison() : base(3000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Poison Mist");
            Tooltip.SetDefault("Pyromancy that conjures a mist of poison.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 4;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 20;
            item.knockBack = 0f;
            item.shootSpeed = 2.0f;
            item.value = Item.buyPrice(0, 0, 15, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.PoisonBreath>();
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