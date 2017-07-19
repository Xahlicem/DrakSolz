using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace XahlicemMod.Projectiles {
    public class MGSProj : ModProjectile {

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
            projectile.width = 25;
            projectile.height = 55;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.damage = 10;

            //projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            //projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
        }

        bool shot = false;

        public override void AI() {

            if (!shot) {
                projectile.position.Y -= 15;
                shot = true;
            }
            projectile.frame = (int) projectile.localAI[0];
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            // Set to transparant. This projectile technically lives as  transparant for about 3 frames

            projectile.tileCollide = false;
            projectile.alpha = 255;

            // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);

            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);

            projectile.width = 100;

            projectile.height = 100;

            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);

            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

            projectile.damage = 10;

            projectile.knockBack = 10f;
            projectile.velocity = new Vector2(0f, 0f);
            projectile.timeLeft = 3;
            return false;
        }

        public override void Kill(int timeLeft) {
            // Play explosion sound

            Main.PlaySound(SoundID.Item15, projectile.position);

            // Smoke Dust spawn

            for (int i = 0; i < 50; i++)

            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);

                Main.dust[dustIndex].velocity *= 1.4f;

            }

            // Fire Dust spawn

            for (int i = 0; i < 80; i++)

            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 3f);

                Main.dust[dustIndex].noGravity = true;

                Main.dust[dustIndex].velocity *= 2f;

                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 2f);

                Main.dust[dustIndex].velocity *= 1.5f;

            }

            // Large Smoke Gore spawn

            for (int g = 0; g < 2; g++)

            {

                int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

                Main.gore[goreIndex].scale = 1.5f;

                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;

                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

                goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

                Main.gore[goreIndex].scale = 1.5f;

                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;

                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

                goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

                Main.gore[goreIndex].scale = 1.5f;

                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;

                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;

                goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

                Main.gore[goreIndex].scale = 1.5f;

                Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;

                Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;

            }
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 1.2f) {
                vector *= 60f / magnitude;
            }
        }

    }
}