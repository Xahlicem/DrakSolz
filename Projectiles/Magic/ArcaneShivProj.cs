using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class ArcaneShivProj : ModProjectile {

        public override void SetStaticDefaults() {
            ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Typhoon);
            projectile.penetrate = 5;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
        }
        public override void AI() {
            if (projectile.timeLeft <= 60) {
                projectile.velocity *= 0.98f;
            }
            projectile.scale = 1.25f;
            projectile.rotation += 0.05f * projectile.direction;
            projectile.alpha = 0;
            if (projectile.timeLeft % 3 == 0) {
                int proj = Projectile.NewProjectile(projectile.Center, new Vector2(0, 0f), mod.ProjectileType<Magic.ArcaneShivProj1>(), projectile.damage, 0, projectile.owner);
                Main.projectile[proj].rotation = projectile.rotation;
                Main.projectile[proj].magic = true;
                Main.projectile[proj].timeLeft = 20;
            }

        }
        public override void Kill(int timeLeft) {

            for (int i = 0; i < projectile.frame * 5 + 5; i++) {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0, 0, 0, Color.Aquamarine, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 0.5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 0, Color.Aquamarine, 2f);
                Main.dust[dustIndex].velocity *= 0.5f;
                Main.dust[dustIndex].scale *= 0.5f;
            }
        }
    }
}