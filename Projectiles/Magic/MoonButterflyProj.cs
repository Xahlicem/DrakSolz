using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class MoonButterflyProj : ModProjectile {

        public override void SetStaticDefaults() {
            ProjectileID.Sets.Homing[projectile.type] = false;
            Main.projFrames[projectile.type] = 1;
            Main.projHostile[projectile.type] = true;
        }

        public override void SetDefaults() {
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 14;
            projectile.height = 40;
            projectile.timeLeft = 60;
            projectile.penetrate = -1;
            projectile.knockBack = 0f;
        }

        /*public override void OnHitPlayer (Player target, int damage, bool crit) {
            projectile.Kill ();
        }*/

        public override void AI() {
            projectile.ai[0]++;
            if (projectile.owner == 255) {
                projectile.hostile = true;
                projectile.friendly = false;
            } else {
                projectile.hostile = false;
                projectile.friendly = true;
            }
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight);
            Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
        }

        public override void Kill(int timeLeft) {
            for (int i = 0; i < 30; i++) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
    }
}