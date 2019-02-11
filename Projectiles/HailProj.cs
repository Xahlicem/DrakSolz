using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class HailProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_344"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Crystal Hail");
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(337);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 45;
        }

        public override void Kill(int timeLeft) {
            int numberProjectiles = 8 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.X).RotatedByRandom(MathHelper.ToRadians(360)); // 30 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale * 0.5f;
                int pro = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.IceSpike, projectile.damage, 3, projectile.owner);
                Main.projectile[pro].hostile = false;
                Main.projectile[pro].friendly = true;
                Main.projectile[pro].penetrate = 1;
            }
        }
    }
}