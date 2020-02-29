using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class FloatingChaosProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Floating Chaos");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults() {
            projectile.width = 50;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 360;
        }

        public override void AI() {
            projectile.ai[0]++;
            int dust = Dust.NewDust(new Vector2(projectile.Hitbox.X, projectile.Hitbox.Y), projectile.width, projectile.height, DustID.Fire);
            Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
            if (Main.time % 6 == 0) {
                projectile.frame++;
                if (projectile.frame >= 4) {
                    projectile.frame = 0;
                projectile.rotation += 1;
                }
            }
            if (projectile.timeLeft == 360) {
                projectile.velocity.Y = -2;
            }
            if (projectile.timeLeft == 330) {
                projectile.velocity.Y = -1;
            }
            if (projectile.timeLeft == 300) {
                projectile.velocity.Y = 0;
            }

            if (projectile.timeLeft == 300 || projectile.timeLeft == 285 || projectile.timeLeft == 270 || projectile.timeLeft == 255 ||
            projectile.timeLeft == 240 || projectile.timeLeft == 225 || projectile.timeLeft == 210 || projectile.timeLeft == 195 ||
            projectile.timeLeft == 180 || projectile.timeLeft == 165 || projectile.timeLeft == 150 || projectile.timeLeft == 135 ||
            projectile.timeLeft == 120 || projectile.timeLeft == 105 || projectile.timeLeft == 90 || projectile.timeLeft == 75 ||
            projectile.timeLeft == 60 || projectile.timeLeft == 45 || projectile.timeLeft == 30) {
                Vector2 mouse = new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y);
                mouse = mouse - projectile.Center;
                DrakSolz.AdjustMagnitude(ref mouse, 18f);
                int proj = Projectile.NewProjectile(projectile.Center, mouse, ProjectileID.Flamelash, projectile.damage, 3.5f, projectile.owner);
                Main.projectile[proj].timeLeft = 90;
                Main.projectile[proj].magic = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].velocity *= 0.5f;
            }
            return;
        }
    }
}