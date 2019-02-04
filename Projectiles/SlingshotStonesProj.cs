using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class SlingshotStonesProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_99"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Slingshot");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Bone);
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.timeLeft = 600;
            projectile.scale = 0.4f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }
                public override void Kill(int timeLeft) {
            for (int i = 0; i < 20; i++) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Dirt);
                Main.dust[dust].velocity *= 1.0f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 0.4f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
    }
}