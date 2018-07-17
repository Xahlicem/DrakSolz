using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class WhiteCoronaProj1 : ModProjectile {

        public override void SetStaticDefaults() {
            //ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults() {
            aiType = ProjectileID.DemonScythe; //Act exactly like default Bullet
            projectile.width = 50; //The width of projectile hitbox
            projectile.height = 50; //The height of projectile hitbox
            projectile.aiStyle = 0; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true; //Can the projectile deal damage to enemies?
            projectile.hostile = false; //Can the projectile deal damage to the player?
            projectile.magic = false;
            projectile.minion = true; //Is the projectile shoot by a magic weapon?
            projectile.penetrate = -1; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 60; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 2.0f; //How much light emit around the projectile
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true; //Can the projectile collide with tiles?
            projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.scale *= 1.0f;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 35;
            height = 35;
            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times
            projectile.penetrate--;
            if (projectile.penetrate <= 0) {
                projectile.Kill();
            } else {
                if (projectile.velocity.X != oldVelocity.X) {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y) {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
        public override void AI() {
            if (projectile.timeLeft <= 60) {
                projectile.velocity *= 0.98f;
            }
            if (++projectile.frameCounter >= 2) {
                if (projectile.timeLeft >= 10)

                projectile.frameCounter = 0;
                if (++projectile.frame >= 4) {
                    projectile.frame = 0;
                }
            }
            projectile.alpha = 0;
            if (projectile.timeLeft <= 20) {
                projectile.alpha -= 10;
            }
            if (projectile.timeLeft % 3 == 0) {
                int proj = Projectile.NewProjectile(projectile.Center, new Vector2(0, 0f), mod.ProjectileType<WhiteCoronaProj2>(), projectile.damage, 0, projectile.owner);
                Main.projectile[proj].rotation = projectile.rotation;
                Main.projectile[proj].magic = false;
                Main.projectile[proj].minion = true;
                Main.projectile[proj].timeLeft = 20;
                Main.projectile[proj].scale = projectile.scale;
            }

        }
        public override void Kill(int timeLeft) {

            for (int i = 0; i < projectile.frame * 5 + 5; i++) {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0, 0, 0, Color.White, 8f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 0.5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 0, Color.White, 6f);
                Main.dust[dustIndex].velocity *= 0.5f;
                Main.dust[dustIndex].scale *= 0.5f;
            }
        }
    }
}