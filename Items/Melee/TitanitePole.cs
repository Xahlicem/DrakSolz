using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class TitanitePole : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanite Pole");
            Tooltip.SetDefault("Attack power increased when falling. Right click for special interaction.");
        }

        public override void SetDefaults() {
            item.damage = 80;
            item.useStyle = 5;
            item.useAnimation = 34;
            item.useTime = 40;
            item.shootSpeed = 4.4f;
            item.knockBack = 8.5f;
            item.width = 28;
            item.height = 28;
            item.scale = 1f;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<Projectiles.TitanitePoleProj>();
            item.value = 1000000;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player) {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.velocity.Y != 0 && player.altFunctionUse == 2) {
                player.velocity.Y = ((int) 1 * player.maxFallSpeed);
            }
            damage = (int)(damage + (3 * (player.velocity.Y) * (player.meleeDamage)));
            //int pro = Projectile.NewProjectile(player.Center.X, player.Center.X, (int)speedX, (int)speedY, type, (int)(damage + (5 * (player.velocity.Y))), 6.5f, player.whoAmI);
            return true;
        }
        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}