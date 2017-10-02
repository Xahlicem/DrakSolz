using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class ArcaneShivProj1 : ModProjectile {

        public override void SetStaticDefaults() {
            //ProjectileID.Sets.Homing[projectile.type] = false;
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.MagicDagger);
        }
        public override void AI() {
            /*int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0, 0, 0, Color.DodgerBlue, 0.5f);
            Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;*/
            if (projectile.timeLeft < 20) {
                projectile.alpha += 12;
                projectile.scale -= 0.03f;

            }
        }
    }
}