using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class BoneWheelProj : ModProjectile {

        public override void SetDefaults() {
            projectile.tileCollide = false;
            projectile.width = 30;
            projectile.height = 60;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            projectile.timeLeft = 100;
            projectile.alpha = 255;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center;
            projectile.velocity.X = projectile.ai[0]*15;
            projectile.direction = (int) projectile.ai[0];

            int i = player.FindBuffIndex(mod.BuffType<Buffs.BoneWheelMount>());
            if (i != -1) {
                projectile.timeLeft = 5;
            }
        }
    }
}