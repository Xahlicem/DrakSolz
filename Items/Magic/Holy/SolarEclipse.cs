using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class SolarEclipse : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Solar Eclipse");
            Tooltip.SetDefault("Miracle that projects a ring of Energy." +
                "\n Fires a more powerful ring at higher mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 5;
            item.magic = false;
            item.damage = 50;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 45;
            item.useAnimation = 45;
            item.mana = 10;
            item.knockBack = 1.0f;
            item.shootSpeed = 8.0f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.WhiteCoronaProj1>();
            item.summon = true;
        }

        //public override void AddRecipes() {
        //ModRecipe recipe = new SoulRecipe(mod, this);
        //recipe.AddIngredient(mod.ItemType<Items.Misc.PyroScroll>());
        //recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
        //recipe.AddRecipe();
        //}
        public override bool CanUseItem(Player player) {
item.mana = (((player.statMana + 10) / 5) - (20/21));
                return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;

            if (player.statMana >= (((player.statManaMax2) * 1) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 2;
                Main.projectile[pro].scale *= 1.5f;
                Main.projectile[pro].penetrate = 40;
                Main.projectile[pro].velocity *= 2.0f;
                Main.projectile[pro].timeLeft = 300;
                Main.projectile[pro].light = 3.0f;
            } else if (player.statMana >= (((player.statManaMax2) * 0.8) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 1.15f;
                Main.projectile[pro].penetrate = 20;
                Main.projectile[pro].velocity *= 1.6f;
                Main.projectile[pro].timeLeft = 150;
                Main.projectile[pro].light = 2.5f;
            } else if (player.statMana >= (((player.statManaMax2) * 0.6) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 1.0f;
                Main.projectile[pro].penetrate = 16;
                Main.projectile[pro].velocity *= 1.4f;
                Main.projectile[pro].timeLeft = 130;
                Main.projectile[pro].light = 2.0f;
            } else if (player.statMana >= (((player.statManaMax2) * 0.4) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.85f;
                Main.projectile[pro].penetrate = 12;
                Main.projectile[pro].velocity *= 1.2f;
                Main.projectile[pro].timeLeft = 110;
                Main.projectile[pro].light = 1.5f;
            } else if (player.statMana >= (((player.statManaMax2) * 0.2) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.7f;
                Main.projectile[pro].penetrate = 8;
                Main.projectile[pro].velocity *= 1.0f;
                Main.projectile[pro].timeLeft = 90;
                Main.projectile[pro].light = 1.0f;
            } else if (player.statMana >= 2) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.55f;
                Main.projectile[pro].penetrate = 4;
                Main.projectile[pro].velocity *= 0.8f;
                Main.projectile[pro].timeLeft = 70;
                Main.projectile[pro].light = 0.5f;
            } else {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.4f;
                Main.projectile[pro].penetrate = 2;
                Main.projectile[pro].velocity *= 0.6f;
                Main.projectile[pro].timeLeft = 50;
                Main.projectile[pro].light = 0.25f;
            }
            return false;
        }
    }
}