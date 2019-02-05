using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class PoisonBreath3 : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_244"; } }

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 6;
            DisplayName.SetDefault("Acid Surge");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.SporeCloud);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.timeLeft = 200;
            projectile.scale = 1.0f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.alpha = 200;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.Ichor, 600);
            target.AddBuff(BuffID.Oiled, 600);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.Ichor, 600);
            target.AddBuff(BuffID.Oiled, 600);
        }

        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.Ichor, 600);
            target.AddBuff(BuffID.Oiled, 600);
        }
        public override void AI() {

            projectile.ai[0]++;
            if (projectile.ai[0] % 2 == 0) return;
            if (projectile.timeLeft >= 120) {
                projectile.scale *= 1.03f;
            }
            if (projectile.timeLeft <= 117) {
                projectile.scale *= 1.01f;
            }
            if (projectile.timeLeft >= 130) {
                projectile.alpha -= 6;
            }
            if (projectile.timeLeft <= 70) {
                projectile.alpha += 6;
            }
        }
    }
}