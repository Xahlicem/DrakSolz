using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class TorchLightProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_21"; } }

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
            DisplayName.SetDefault("Fire");
        }

        public override void SetDefaults() {
            projectile.alpha = 255;
            projectile.timeLeft = 30;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.light = 2;
        }
    }
}