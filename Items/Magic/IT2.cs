using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class IT2 : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Immolation Tinder");
            Tooltip.SetDefault("Staff used by Flame Warmages, conjures a great pillar of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.damage = 70;
            item.useTime = 40;
            item.useAnimation = 40;
            item.mana = 15;
            item.knockBack = 0f;
            item.shootSpeed = 0f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.Magic.FlameMageProj1>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 40, type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}