using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class WhiteCoronaProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("White Corona"); //The English name of the projectile
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

            if (projectile.timeLeft < 30) {
                projectile.alpha += 8;
                projectile.scale -= 0.02f;
                projectile.velocity *= 0.96f;
            }
            if (++projectile.frameCounter >= 2) {
                if (projectile.timeLeft >= 20) {
                    int proj = Projectile.NewProjectile(projectile.Center, Vector2.Zero, projectile.type, 0, 0, projectile.owner);
                    Main.projectile[proj].position.X += 0;
                    Main.projectile[proj].alpha = projectile.alpha + 80;
                    Main.projectile[proj].timeLeft = 19;
                    Main.projectile[proj].scale = projectile.scale;
                    Main.projectile[proj].rotation = projectile.rotation;
                    Main.projectile[proj].direction = projectile.direction;
                }

                projectile.frameCounter = 0;
                if (++projectile.frame >= 4) {
                    /*if (projectile.timeLeft >= 10) {
                        int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0, 0), ModContent.ProjectileType<Projectiles.WhiteCoronaProj>(), projectile.damage * 0, 0, projectile.owner);
                        Main.projectile[proj].alpha = 100;
                        Main.projectile[proj].timeLeft = 9;
                        Main.projectile[proj].velocity *= 0.1f;
                        Main.projectile[proj].scale = projectile.scale;
                    }*/
                    projectile.frame = 0;
                }
            }

            projectile.ai[0]++;

        }
    }
}