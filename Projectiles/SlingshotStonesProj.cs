using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class SlingshotStonesProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.Boulder; } }

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
    public class SlingshotMoltenSpikyProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.SpikyBall; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Slingshot");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.SpikyBall);
        }

        public override void AI() {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
            Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.OnFire, 150);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 150);
        }

        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 150);
        }
    }
}