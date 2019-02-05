using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class PoisonBreath : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_468"; } }

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 4;
            DisplayName.SetDefault("Poison Mist");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.SporeCloud);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.timeLeft = 180;
            projectile.scale = 0.8f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.alpha = 255;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.Poisoned, 1800);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.Poisoned, 1800);
        }

        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.Poisoned, 1800);
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
            
            if (projectile.timeLeft >= 120) {
                projectile.alpha -= 6;
            }
            if (projectile.timeLeft <= 60) {
                projectile.alpha += 6;
            }
        }
    }
}