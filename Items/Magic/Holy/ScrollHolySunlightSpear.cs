using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolySunlightSpear : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sunlight Spear");
            Tooltip.SetDefault("Miracle that sends a spear of sunlight piercing through the heavens." +
                "\n Fires a more powerful spear at higher mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 1;
            item.magic = true;
            item.damage = 120;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.mana = 12;
            item.knockBack = 6.0f;
            item.shootSpeed = 20.0f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.SunlightSpearProj>();
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Magic.Holy.ScrollHolyGreatLightningSpear>());
            recipe.AddIngredient(mod.ItemType<Items.Souls.GolemSoul>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;

            if (player.statMana >= (((player.statManaMax2) * 0.75) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 1.0f;
                Main.projectile[pro].penetrate = 5;
                Main.projectile[pro].velocity *= 1.0f;
                Main.projectile[pro].timeLeft = 60;
                Main.projectile[pro].knockBack *= 1.0f;

            }
            else if (player.statMana >= (((player.statManaMax2) * 0.50) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.85f;
                Main.projectile[pro].penetrate = 3;
                Main.projectile[pro].velocity *= 0.9f;
                Main.projectile[pro].timeLeft = 55;
                Main.projectile[pro].knockBack *= 0.9f;
            }
            else if (player.statMana >= (((player.statManaMax2) * 0.25) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.70f;
                Main.projectile[pro].penetrate = 2;
                Main.projectile[pro].velocity *= 0.8f;
                Main.projectile[pro].timeLeft = 50;
                Main.projectile[pro].knockBack *= 0.8f;
            }
            else {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.55f;
                Main.projectile[pro].penetrate = 1;
                Main.projectile[pro].velocity *= 0.7f;
                Main.projectile[pro].timeLeft = 45;
                Main.projectile[pro].knockBack *= 0.7f;
            }
            return false;
        }
    }
}