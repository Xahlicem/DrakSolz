using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class HereticProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_579"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton's Bone");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(579);
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
        }

        public override void AI() {
            projectile.ai[0]++;

            if (projectile.timeLeft == 120 || projectile.timeLeft == 116 || projectile.timeLeft == 112 || projectile.timeLeft == 108 || projectile.timeLeft == 104 || projectile.timeLeft == 100 || projectile.timeLeft == 96 || projectile.timeLeft == 92) {
                Vector2 mouse = new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y);
                mouse = mouse - projectile.Center;
                DrakSolz.AdjustMagnitude(ref mouse, 18f);
                int proj = Projectile.NewProjectile(projectile.Center, mouse, ProjectileID.PhantasmalBolt, projectile.damage, 3.5f, projectile.owner);
                Main.projectile[proj].magic = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].velocity *= 0.5f;
            }
            return;
        }
    }
}