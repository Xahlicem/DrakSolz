using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class FireProj2 : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_85"; } }

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
            DisplayName.SetDefault("Fire");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Flames);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.scale = 1.0f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
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