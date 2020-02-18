using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class ADaggerProj : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 30;
            projectile.height = 30;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
        }

        bool shot = false;
        public override void AI() {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.BlueCrystalShard);
            Main.dust[dust].velocity *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.BlueCrystalShard);
            Main.dust[dust2].velocity *= 0.25f + Main.rand.NextFloat();
            Main.dust[dust2].scale *= 0.8f + Main.rand.NextFloat();
            Main.dust[dust2].noGravity = true;
            if (!shot) {
                projectile.position.Y += 4;
                shot = true;
            }
            projectile.frame = (int) projectile.localAI[0];
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(45f);
            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.Frostburn, 60);
        }
    }
}