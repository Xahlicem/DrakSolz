﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class VorpalDaggerProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Vorpal Dagger"); //The English name of the projectile
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; //The recording mode
        }

        public override void SetDefaults() {
            projectile.width = 8; //The width of projectile hitbox
            projectile.height = 12; //The height of projectile hitbox
            projectile.aiStyle = 1; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true; //Can the projectile deal damage to enemies?
            projectile.hostile = false; //Can the projectile deal damage to the player?
            projectile.magic = false; //Is the projectile shoot by a magic weapon?
            projectile.thrown = true;
            projectile.penetrate = 2; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 600; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true; //Can the projectile collide with tiles?
            projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.scale *= 1.0f;
            aiType = ProjectileID.ShadowBeamFriendly; //Act exactly like default Bullet
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 4;
            height = 8;
            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
            projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
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
            projectile.ai[0]++;
        }
        
        public override void Kill(int timeLeft) {

            for (int i = 0; i < projectile.frame * 5 + 5; i++) {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0, 0, 150, Color.Black, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 0.5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 150, Color.Black, 2f);
                Main.dust[dustIndex].velocity *= 0.25f;
                Main.dust[dustIndex].scale *= 0.5f;
            }
        }
    }
}