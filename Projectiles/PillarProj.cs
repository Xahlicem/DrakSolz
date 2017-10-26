using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class PillarProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pillar Orb");
        }

        public override void SetDefaults() {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 0;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 2400;
            projectile.alpha = 0;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.scale *= 1;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }
        public override void AI() {

            projectile.ai[0]++;
            if (projectile.ai[0] % 2 == 0) return;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, 0, 0, 0, Color.Black);
            Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
        }
    }
}