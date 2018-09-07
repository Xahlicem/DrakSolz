using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class EnemyHereticProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_579"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton's Bone");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(579);
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
        }

        public override void AI() {
            projectile.ai[0]++;

            if (projectile.timeLeft == 120 || projectile.timeLeft == 110 || projectile.timeLeft == 100 || projectile.timeLeft == 90) {
                for (int k = 0; k < 1; k++) {
                Vector2 newMove = Main.player[k].Center - projectile.Center;
                DrakSolz.AdjustMagnitude(ref newMove, 18f);
                int proj = Projectile.NewProjectile(projectile.Center, newMove, ProjectileID.PhantasmalBolt, projectile.damage, 3.5f, projectile.owner);
                Main.projectile[proj].magic = true;
                Main.projectile[proj].hostile = true;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].velocity *= 0.1f;
                }
            }
            return;
        }
    }
}