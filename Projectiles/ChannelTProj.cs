using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class ChannelTProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Channeler's Trident");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults() {

            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 0.6f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.alpha = 0;
            projectile.light = 0.5f;
        }

        // In here the AI uses this example, to make the code more organized and readible
        // Also showcased in ExampleJavelinProjectile.cs
        public float movementFactor // Change this value to alter how fast the spear moves
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }
        // It appears that for this AI, only the ai0 field is used!

        public override void AI() {
            if (projectile.ai[0] <= 3f) projectile.frame = 0;
            else projectile.frame = (int)(projectile.ai[0] / 8);
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            // Sadly, Projectile/ModProjectile does not have its own
            Player projOwner = Main.player[projectile.owner];
            //projOwner.AddBuff(mod.BuffType("ChannelBuff"), 40);
            float distance = 325f;

            for (int k = 0; k < 200; k++) {
                if (Main.player[k].active && Main.player[k].team == projOwner.team) {
                    if (projOwner.WithinRange(Main.player[k].Center, distance)) {
                        if (projOwner.setBonus.Contains("Channeler's Perfect Dance"))
                            Main.player[k].AddBuff(mod.BuffType("ChannelBuff2"), 40);
                        else Main.player[k].AddBuff(mod.BuffType("ChannelBuff"), 40);
                    }
                }
            }

            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile directio and position based on the player
            Vector2 mountedCenter = projOwner.MountedCenter;
            mountedCenter.X -= 10;
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(mountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen) {
                if (movementFactor == 0f) // When intially thrown out, the ai0 will be 0f
                {
                    movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 2) // Somewhere along the item animation, make sure the spear moves back
                {
                    movementFactor -= 1.0f;
                } else // Otherwise, increase the movement factor
                {
                    movementFactor += 2.1f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * movementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation <= 0) {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

        }

        bool hit = false;

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Main.rand.Next(2) == 0) {
                //Main.player[projectile.owner].AddBuff(mod.BuffType("ChannelBuff"), 40);
            }
        }
    }
}