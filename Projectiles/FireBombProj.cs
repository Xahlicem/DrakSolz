using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class FireBombProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Bomb");
        }

        public override void SetDefaults() {
            projectile.scale = 0.75f;
            projectile.tileCollide = true;
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
        }
        public override void AI() {
            if (projectile.velocity.X < 0) {
                projectile.spriteDirection = -1;
            }
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(360f);
            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(180f);
            }
            if (projectile.timeLeft <= 590) {
                projectile.velocity.Y += 0.5f;
                if (projectile.timeLeft <= 570) {
                    projectile.velocity.Y += 0.5f;
                    if (projectile.timeLeft <= 520) {
                        projectile.velocity.Y += 1;
                        if (projectile.timeLeft <= 480) {
                            projectile.velocity.Y += 2;
                            if (projectile.timeLeft <= 420) {
                                projectile.velocity.Y += 3;
                            }
                        }
                    }
                }
            }
        }

        public override void Kill(int timeLeft) {
            Main.PlaySound(SoundID.Item15, projectile.position);

            int proj = Projectile.NewProjectile(projectile.Center, projectile.velocity, ProjectileID.GrenadeI, projectile.damage, 0.25f, projectile.owner);
            Main.projectile[proj].thrown = true;
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 1;
        }
    }
}