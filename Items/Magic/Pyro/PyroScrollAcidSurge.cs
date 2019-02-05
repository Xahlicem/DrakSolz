using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollAcidSurge : SoulItem {
        public PyroScrollAcidSurge() : base(40000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Acid Surge");
            Tooltip.SetDefault("Pyromancy that conjures a surge of acid, corroding armor.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 8;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 50;
            item.knockBack = 0f;
            item.shootSpeed = 2.0f;
            item.value = Item.buyPrice(0, 0, 15, 0);
            item.shoot = mod.ProjectileType<Projectiles.PoisonBreath3>();
        }


        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Magic.Pyro.PyroScrollPoison>());
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