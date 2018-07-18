using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class WhiteCoronaProj2 : ModProjectile {

        public override void SetStaticDefaults() {
            //ProjectileID.Sets.Homing[projectile.type] = false;
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
            width = 25;
            height = 25;
            return true;
        }
        public override void AI() {
            if (++projectile.frameCounter >= 2) {
                if (projectile.timeLeft >= 10)

                    projectile.frameCounter = 0;
                if (++projectile.frame >= 4) {
                    projectile.frame = 0;
                }
                /*int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0, 0, 0, Color.DodgerBlue, 0.5f);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;*/
                if (projectile.timeLeft >= 10) {
                    projectile.alpha += 12;
                    projectile.scale -= 0.03f;
                } else if (projectile.timeLeft < 10) {
                    projectile.alpha += 12;
                    projectile.scale -= 0.03f;

                }
            }
        }
    }
}