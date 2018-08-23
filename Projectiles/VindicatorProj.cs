using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class VindicatorProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Vindicator Blade"); //The English name of the projectile
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; //The recording mode
        }

        public override void SetDefaults() {
            projectile.width = 34; //The width of projectile hitbox
            projectile.height = 6; //The height of projectile hitbox
            projectile.aiStyle = 0; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true; //Can the projectile deal damage to enemies?
            projectile.hostile = false; //Can the projectile deal damage to the player?
            projectile.magic = false; //Is the projectile shoot by a magic weapon?
            projectile.melee = true;
            projectile.light = 1.0f;
            projectile.penetrate = 4; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 90; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true; //Can the projectile collide with tiles?
            projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.scale *= 2.0f;
            aiType = ProjectileID.ShadowBeamFriendly; //Act exactly like default Bullet
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 28;
            height = 3;
            return true;
        }
        public override void AI() {
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(360f);
            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(270f);
            }
            projectile.ai[0]++;
        }
    }
}