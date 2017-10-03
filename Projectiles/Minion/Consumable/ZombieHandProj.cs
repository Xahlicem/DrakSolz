using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public class ZombieHandProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Zombie's Hand");
        }

        public override void SetDefaults() {
            projectile.aiStyle = 2;
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.minion = true;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 18;
            height = 16;
            return true;
        }

        public override void AI() {
            if (Math.Abs(projectile.velocity.X) > 0f) projectile.spriteDirection = projectile.direction;
        }

        public override void Kill(int timeLeft) {
            int pro = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - 15), new Vector2(projectile.direction * 0.01f, 0), mod.ProjectileType<Projectiles.Minion.Consumable.Zombie>(), projectile.damage, projectile.knockBack, projectile.owner);
            Main.projectile[pro].spriteDirection = projectile.spriteDirection;
        }
    }
}