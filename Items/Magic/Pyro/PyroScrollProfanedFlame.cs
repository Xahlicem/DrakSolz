using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollProfanedFlame : SoulItem {
        public PyroScrollProfanedFlame() : base(25000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Profaned Flame");
            Tooltip.SetDefault("Conjures a flame which explodes after a small delay.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 45;
            item.mana = 20;
            item.knockBack = 9f;
            item.shootSpeed = 0.01f;
            item.value = Item.buyPrice(0, 30, 0, 0);
            item.shoot = mod.ProjectileType<Projectiles.ProfanedProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            Main.projectile[pro].scale *= 1.0f;
            Main.projectile[pro].hostile = false;
            Main.projectile[pro].friendly = false;
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Twink>());
            recipe.AddIngredient(mod.ItemType<Items.Misc.PyroScroll>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}