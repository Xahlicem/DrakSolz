﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class SorcSwordProj : ModProjectile {

        public override void SetStaticDefaults() {
            //ProjectileID.Sets.Homing[projectile.type] = false;
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            //projectile.CloneDefaults(ProjectileID.TerraBladeBeam);
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.penetrate = 1;
            projectile.timeLeft = 30;

            //projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            //projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
        }

        public override void AI() {

            if (projectile.ai[0] == 0) {
                Vector2 mouse = new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y);
                mouse = mouse - projectile.Center;
                DrakSolz.AdjustMagnitude(ref mouse, 25f);
                projectile.velocity = mouse;

                for (int i = 0; i < 25; i++) {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].scale *= 0.5f;
                }
            }
            projectile.frame = (int) projectile.localAI[0];
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(270f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            projectile.ai[0]++;
        }

        public override void Kill(int timeLeft) {
            // Play explosion sound

            Main.PlaySound(SoundID.Item15, projectile.position);

            // Fire Dust spawn

            for (int i = 0; i < 10; i++)

            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 3f);

                Main.dust[dustIndex].noGravity = true;

                Main.dust[dustIndex].scale *= 0.5f;

                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 2f);

                Main.dust[dustIndex].velocity *= 0.5f;

                Main.dust[dustIndex].scale *= 0.5f;

            }
        }
    }
}