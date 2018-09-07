using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class HereticSpell : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Heretic's Spellbook");
            Tooltip.SetDefault("Staff used by Mechanysts, conjures a howling tornado.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 5;
            item.scale *= 1;
            item.magic = true;
            item.noMelee = true;
            item.damage = 1300;
            item.useTime = 30;
            item.useAnimation = 30;
            item.rare = 4;
            item.mana = 50;
            item.knockBack = 8f;
            item.shootSpeed = 0f;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType<Projectiles.HereticProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].hostile = false;
            Main.projectile[pro].friendly = false;
            Main.projectile[pro].ai[1] = 1;
            return false;
        }
    }
}