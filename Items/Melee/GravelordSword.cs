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
            item.damage = 90;
            item.useTime = 25;
            item.useAnimation = 25;
            item.rare = 8;
            item.knockBack = 11f;
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
            if (player.statMana >= item.buffTime * player.manaCost) {
                damage *= 2;
                player.statMana -= (int)(item.buffTime * player.manaCost);
                item.mana = item.buffTime;
                int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, ((Main.mouseX + Main.screenPosition.X) - player.position.X), 40, type, (int)(damage * 0.65f), 0, player.whoAmI);
                return false;
            }
            item.mana = item.buffTime;
            return false;
        }
    }
}