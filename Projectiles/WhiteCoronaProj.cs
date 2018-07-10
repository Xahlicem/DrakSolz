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
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; //The recording mode
        }

        public override void SetDefaults() {
            projectile.width = 16; //The width of projectile hitbox
            projectile.height = 16; //The height of projectile hitbox
            projectile.aiStyle = 27; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true; //Can the projectile deal damage to enemies?
            projectile.hostile = false; //Can the projectile deal damage to the player?
            projectile.magic = true; //Is the projectile shoot by a magic weapon?
            projectile.penetrate = -1; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 60; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 2.0f; //How much light emit around the projectile
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true; //Can the projectile collide with tiles?
            projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.scale *= 1.0f;
            aiType = ProjectileID.ShadowBeamFriendly; //Act exactly like default Bullet
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 12;
            height = 12;
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
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);
            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            if (projectile.timeLeft < 20) {
                projectile.alpha += 12;
                projectile.scale -= 0.03f;
            }
            if (++projectile.frameCounter >= 2) {
                if (projectile.timeLeft >= 10) {
                int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0, 0), mod.ProjectileType<Projectiles.WhiteCoronaProj>(), projectile.damage * 0, 0, projectile.owner);
                Main.projectile[proj].alpha = 100;
                Main.projectile[proj].timeLeft = 9;
                Main.projectile[proj].velocity *= 0.1f;
                Main.projectile[proj].scale = projectile.scale;
                }

                projectile.frameCounter = 0;
                if (++projectile.frame >= 4) {
                    /*if (projectile.timeLeft >= 10) {
                        int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0, 0), mod.ProjectileType<Projectiles.WhiteCoronaProj>(), projectile.damage * 0, 0, projectile.owner);
                        Main.projectile[proj].alpha = 100;
                        Main.projectile[proj].timeLeft = 9;
                        Main.projectile[proj].velocity *= 0.1f;
                        Main.projectile[proj].scale = projectile.scale;
                    }*/
                    projectile.frame = 0;
                }
            }

            projectile.ai[0]++;
            /* if (projectile.timeLeft == 78 || projectile.timeLeft == 76 || projectile.timeLeft == 74 || projectile.timeLeft == 72 || projectile.timeLeft == 70 ||
                 projectile.timeLeft == 68 || projectile.timeLeft == 66 || projectile.timeLeft == 64 || projectile.timeLeft == 62 || projectile.timeLeft == 60 ||
                 projectile.timeLeft == 58 || projectile.timeLeft == 56 || projectile.timeLeft == 54 || projectile.timeLeft == 52 || projectile.timeLeft == 50 ||
                 projectile.timeLeft == 48 || projectile.timeLeft == 46 || projectile.timeLeft == 44 || projectile.timeLeft == 42 || projectile.timeLeft == 40 ||
                 projectile.timeLeft == 38 || projectile.timeLeft == 36 || projectile.timeLeft == 34 || projectile.timeLeft == 32 || projectile.timeLeft == 30 ||
                 projectile.timeLeft == 28 || projectile.timeLeft == 26 || projectile.timeLeft == 24 || projectile.timeLeft == 22 || projectile.timeLeft == 20 ||
                 projectile.timeLeft == 18 || projectile.timeLeft == 16 || projectile.timeLeft == 14 || projectile.timeLeft == 12 || projectile.timeLeft == 10) {
                 int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y), new Vector2(0, 0), mod.ProjectileType<Projectiles.WhiteCoronaProj>(), projectile.damage * 0, 0, projectile.owner);
                 Main.projectile[proj].alpha = 100;
                 Main.projectile[proj].timeLeft = 9;
                 Main.projectile[proj].velocity *= 0.1f;            
                 Main.projectile[proj].scale = projectile.scale;
             }*/
        }
    }
}