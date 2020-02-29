using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollChaosStorm : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Firestorm");
            Tooltip.SetDefault("Pyromancy used by the chaos witch herself, conjures multiple pillars of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.magic = false;
            item.damage = 105;
            item.useTime = 40;
            item.useAnimation = 40;
            item.rare = ItemRarityID.Cyan;
            item.mana = 35;
            item.knockBack = 0f;
            item.crit = 4;
            item.shootSpeed = 0f;
            item.value = Item.sellPrice(0, 12, 50, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.FlameMageProj2>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            speedY = 40;
            knockBack = 0f;
            position = new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y);
            int pro = Projectile.NewProjectile(position.X, position.Y - 10, 0, -5, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].friendly = true;
            int pro2 = Projectile.NewProjectile(position.X - 30, position.Y - 10, 0, -5, ModContent.ProjectileType<Projectiles.Magic.FlameMageProj1>(), damage, knockBack, player.whoAmI);
            Main.projectile[pro2].friendly = true;
            int pro3 = Projectile.NewProjectile(position.X + 30, position.Y - 10, 0, -5, ModContent.ProjectileType<Projectiles.Magic.FlameMageProj1>(), damage, knockBack, player.whoAmI);
            Main.projectile[pro3].friendly = true;
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            player.velocity.X = 0;
            player.jump = 0;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireStorm>());
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}