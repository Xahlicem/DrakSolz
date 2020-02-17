using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class HealProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_94"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Healing Wave");
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.PurificationPowder);
            projectile.width = 750;
            projectile.height = 750;
            projectile.alpha = 2;
            projectile.aiStyle = 6;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
            projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {

            target.AddBuff(ModContent.BuffType<Buffs.EnemyHeal>(), 300);
        }
    }
}