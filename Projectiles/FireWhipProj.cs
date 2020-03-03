using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class FireWhipProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_85"; } }

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
            DisplayName.SetDefault("Fire Whip");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.FlamingArrow);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.scale = 0.5f;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 120;
        }public override void AI() {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 35);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 0.75f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.OnFire, 900);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 900);
        }

        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 900);
        }
    }
}