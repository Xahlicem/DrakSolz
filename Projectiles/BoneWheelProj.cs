using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class BoneWheelProj : ModProjectile {
        public override void SetDefaults() {

            projectile.width = 25;
            projectile.height = 25;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.scale = 1.2f;
            projectile.thrown = true;
            projectile.timeLeft = 100;
            projectile.alpha = 0;
            projectile.light = 0.5f;
            projectile.damage = 25;
            projectile.knockBack = 10f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            // This code makes the projectile very bouncy.
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f) {
                projectile.velocity.X = oldVelocity.X * -1f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f) {
                projectile.velocity.Y = oldVelocity.Y * -1f;
            }
            return false;
        }
        public override void AI() {
            if (projectile.rotation < 0.4) {
                projectile.rotation = 0.4f;
            }
            return;
        }

    }
}