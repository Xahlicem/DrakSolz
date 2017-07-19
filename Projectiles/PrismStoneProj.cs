using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace XahlicemMod.Projectiles {
    public class PrismStoneProj : ModProjectile {
        // Brought to you with <3 by Gorateron
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Prism Stone");
        }

        public override void SetDefaults() {
            //projectile.ai[1] = 0;
            // projectile.ai[2] = 0;
            // projectile.ai[3] = 0;
            projectile.tileCollide = true;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            // For going through platforms and such, javelins use a tad smaller size
            width = 10;
            height = 10;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.ai[1] = 1;
            //projectile.ai[2] = projectile.position.X;
            //projectile.ai[3] = projectile.position.Y;
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            projectile.alpha = 255;
            return false;
        }

        public override void Kill(int timeLeft) {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0f); // Play a death sound
            Vector2 usePos = projectile.position; // Position to use for dusts
            // Please note the usage of MathHelper, please use this! We add 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
            usePos += rotVector * 16f;

            // Spawn some dusts upon javelin death
            for (int i = 0; i < 20; i++) {
                // Create a new dust
                int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, 68);
                Dust currentDust = Main.dust[dustIndex]; // If you plan to access the dust often, it's a smart idea to make this local variable to make your life a bit easier
                // Modify some of the dust behaviour
                currentDust.position = (currentDust.position + projectile.Center) / 2f;
                currentDust.velocity += rotVector * 2f;
                currentDust.velocity *= 0.5f;
                currentDust.noGravity = true;
                usePos -= rotVector * 8f;
            }

        }

        // Here's an example on how you could make your AI even more readable, by giving AI fields more descriptive names
        // These are not used in AI, but it is good practice to apply some form like this to keep things organized

        // Added these 2 constant to showcase how you could make AI code cleaner by doing this
        // Change this number if you want to alter how long the javelin can travel at a constant speed
        private const float maxTicks = 20f;
        // Change this number if you want to alter how the alpha changes
        private const int alphaReduction = 25;

        public override void AI() {
            for (int i = 0; i < 20; i++) {
                // Create a new dust
                int dustIndex;
                if (projectile.ai[1] == 1) dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59);
                //if (projectile.ai[1] == 1) dustIndex = Dust.NewDust(new Vector2(projectile.ai[2], projectile.ai[3]), projectile.width, projectile.height, 59);
                else dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59);
                Dust currentDust = Main.dust[dustIndex]; // If you plan to access the dust often, it's a smart idea to make this local variable to make your life a bit easier
                // Modify some of the dust behaviour
                currentDust.position = (currentDust.position + projectile.Center) / 2f;
                currentDust.velocity *= 1.5f;
                currentDust.noGravity = true;
            } {
                projectile.ai[0] += 1f;
                // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
                if (projectile.ai[0] >= maxTicks) {
                    // Change these multiplication factors to alter the javelin's movement change after reaching maxTicks
                    float velXmult = 0.98f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
                    float velYmult = 0.35f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
                    projectile.ai[0] = maxTicks; // set ai1 to maxTicks continuously
                    projectile.velocity.X = projectile.velocity.X * velXmult;
                    projectile.velocity.Y = projectile.velocity.Y + velYmult;
                }
                // Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!

            }
        }
    }
}