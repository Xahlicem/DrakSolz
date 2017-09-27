using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class GravelordProj : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 40;
            projectile.height = 50;
            projectile.timeLeft = 35;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.ai[1] = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.ai[1] = 1;
            return false;
        }

        public override void AI() {
            projectile.ai[0]++;
            if (projectile.ai[1] != 0) {
                projectile.velocity.Y = 0;
                if (projectile.velocity.X > 0) {
                    projectile.velocity.X = 0.01f;
                    projectile.spriteDirection = 1;
                } else if (projectile.velocity.X < 0) {
                    projectile.velocity.X = -0.01f;
                    projectile.spriteDirection = -1;
                }
                if (projectile.timeLeft <= 20) {
                    if (projectile.ai[1] == 1) {
                        //projectile.height = 10;
                        //projectile.position.Y -= 5;
                        projectile.ai[1] = 2;
                    }
                    if (projectile.timeLeft <= 35) {
                        projectile.velocity.Y = 0;
                        projectile.tileCollide = false;
                        if (projectile.timeLeft > 25) {
                            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
                            Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                            Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                            Main.dust[dust].noGravity = true;
                        } else if (projectile.timeLeft <= 25) {
                            projectile.rotation = 0f;
                            projectile.friendly = true;
                            projectile.velocity.Y += -4;
                            projectile.melee = true;
                            projectile.alpha = 80;
                            projectile.scale = 1.5f;
                            projectile.knockBack = 10;
                            //projectile.damage = 80;
                            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AmberBolt);
                            Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                            Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                            Main.dust[dust].noGravity = true;
                        }
                        if (projectile.timeLeft <= 10) {
                            projectile.velocity.Y += 3;
                        }
                    }
                    return;
                }
            } else {
                projectile.velocity.Y = 30;
                projectile.timeLeft = 35;
                projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(270f);
                if (projectile.velocity.X > 0) {
                    projectile.velocity.X = 0.01f;
                } else if (projectile.velocity.X < 0) {
                    projectile.velocity.X = -0.01f;
                }
            }
        }
    }
}