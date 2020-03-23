using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class DragonslayerGreatarrowProjcopy : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dragonslayer Arrow"); //The English name of the projectile
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; //The recording mode
        }

        public override void SetDefaults() {
            projectile.width = 8; //The width of projectile hitbox
            projectile.height = 16; //The height of projectile hitbox
            projectile.aiStyle = 1; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = false; //Can the projectile deal damage to enemies?
            projectile.hostile = true; //Can the projectile deal damage to the player?
            projectile.ranged = true; //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 3; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 600; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            //projectile.light = 0.5f;            //How much light emit around the projectile
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true; //Can the projectile collide with tiles?
            projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.scale *= 2;
            aiType = ProjectileID.BulletHighVelocity; //Act exactly like default Bullet
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 2;
            height = 10;
            return true;
        }
        public override void AI() {
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);
            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            projectile.ai[0]++;
        }
    }
}