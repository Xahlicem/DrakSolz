using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class GravelordSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ravelord Sword");
            Tooltip.SetDefault("Greatsword used by Ravelord Nito.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.scale *= 1.2f;
            item.melee = true;
            item.damage = 105;
            item.useTime = 30;
            item.useAnimation = 30;
            item.rare = 8;
            item.knockBack = 9f;
            item.shootSpeed = 0.01f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.GravelordProj>();
        }
public override bool CanUseItem(Player player) {
            if (item.mana == 0) item.mana = item.alpha;
            else item.alpha = item.mana;
            item.buffTime = item.mana;
            item.mana = 0;
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.statMana >= item.buffTime * player.manaCost && player.ownedProjectileCounts[type] == 0) {
                damage *= 2;
                player.statMana -= (int)(item.buffTime * player.manaCost);
                item.mana = item.buffTime;
                int pro = Projectile.NewProjectile((player.Center.X + (100 *player.direction)), player.Center.Y, 1 * player.direction, 0, type, (int)(damage * 0.60f), 0, player.whoAmI, player.Center.Y);
                //int proj = Projectile.NewProjectile((player.Center.X + (70 *player.direction)) + (50 *player.direction), 1 * player.direction, 40, type, (int)(damage * 0.65f), 0, player.whoAmI);
                //int proje = Projectile.NewProjectile((player.Center.X + (70 *player.direction)) + (100 *player.direction), 1 * player.direction, 40, type, (int)(damage * 0.65f), 0, player.whoAmI);
                return false;
            }
            item.mana = item.buffTime;
            return false;
        }
    }
}