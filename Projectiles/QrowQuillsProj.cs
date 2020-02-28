using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class QrowQuillsProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Qrow Quills"); //The English name of the projectile
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.tileCollide = true;
            projectile.melee = true;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 3;
            height = 6;
            return true;
        }
        public override void Kill(int timeLeft) {

            for (int i = 0; i < projectile.frame * 5 + 5; i++) {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 10, 0, 0, 0, Color.Gray, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 0.25f;
            }
        }
    }
}