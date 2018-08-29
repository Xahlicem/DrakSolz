using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class SpinningAxeProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spinning Axe"); //The English name of the projectile
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Bone);
            projectile.width = 30;
            projectile.height = 90;
            projectile.penetrate = 5;
            projectile.tileCollide = true;
            projectile.timeLeft = 120;
            projectile.magic = false;
            projectile.thrown = true;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 10;
            height = 30;
            return true;
        }
        public override void AI() {
            if (projectile.timeLeft <= 60) {
                projectile.velocity *= 0.98f;
            }
            projectile.scale = 1.0f;
            projectile.rotation += 0.07f * projectile.direction;
            projectile.alpha = 0;

        }
        public override void Kill(int timeLeft) {

            for (int i = 0; i < projectile.frame * 5 + 5; i++) {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 10, 0, 0, 0, Color.White, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 0.5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 10, 0f, 0f, 0, Color.White, 2f);
                Main.dust[dustIndex].velocity *= 0.5f;
                Main.dust[dustIndex].scale *= 0.5f;
            }
        }
    }
}