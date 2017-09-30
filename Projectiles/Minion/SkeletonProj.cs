using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion {
    public class SkeletonProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton's Bone");
        }

        public override void SetDefaults() {
            projectile.aiStyle = 2;
            projectile.width = 24;
            projectile.height = 26;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 19;
            height = 21;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            if (projectile.velocity.Y == 0) {
                if (Math.Abs(projectile.rotation) <= 0.15f) return true;
                else projectile.rotation += (projectile.rotation / 3) * -1;
            }

            return false;
        }

        public override void Kill(int timeLeft) {
            Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - 15), Vector2.Zero, mod.ProjectileType<Projectiles.Minion.SkeletonSummon>(), projectile.damage, projectile.knockBack, projectile.owner);
        }
    }
}