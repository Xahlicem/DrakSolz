using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class HolySpearProj2 : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 40;
            projectile.height = 50;
            projectile.timeLeft = 26;
            projectile.penetrate = -1;
            projectile.alpha = 255;
        }

        public override void AI() {
            projectile.velocity.Y = 0;
            if (projectile.velocity.X > 0) {
                projectile.velocity.X = 0.01f;
                projectile.spriteDirection = 1;
            } else {
                projectile.velocity.X = -0.01f;
                projectile.spriteDirection = -1;
            }
            if (projectile.timeLeft <= 25) {
                //projectile.velocity.X *= 70f;
                projectile.rotation = 100f *(projectile.spriteDirection);
                projectile.friendly = true;
                projectile.velocity.Y += -4;
                projectile.minion = true;
                projectile.scale = 1f;
                projectile.knockBack = 8;
                //projectile.damage = 80;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AmberBolt);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
            if (projectile.timeLeft >= 11 && projectile.alpha >= 55) {
                projectile.alpha -= 20;
            }
            if (projectile.timeLeft <= 10) {
                projectile.velocity.Y += 1;
                projectile.alpha += 18;
            }
            if (projectile.timeLeft <= 5) {
                projectile.velocity.Y += 2;
            }
            if (projectile.timeLeft == 21 && projectile.ai[1] < 7) Projectile.NewProjectile((projectile.Center.X + (40 * projectile.direction)), projectile.ai[0] + 40, 1 * projectile.direction, 0, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1] + 1);
        }
    }
}