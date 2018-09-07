using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class IceSpell : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shattersickle");
            Tooltip.SetDefault("Book of frozen magic.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 5;
            item.scale *= 1;
            item.magic = true;
            item.noMelee = true;
            item.damage = 1600;
            item.useTime = 30;
            item.useAnimation = 30;
            item.rare = 4;
            item.mana = 35;
            item.knockBack = 3f;
            item.shootSpeed = 8f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.IceSpellProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].hostile = false;
            Main.projectile[pro].friendly = true;
            Main.projectile[pro].ai[1] = 1;
            return false;
        }
    }
}