using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class TorchProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_85"; } }

        public override void SetStaticDefaults () {
            Main.projFrames[projectile.type] = 1;
            DisplayName.SetDefault ("Torch Fire");
        }

        public override void SetDefaults () {
            projectile.CloneDefaults (ProjectileID.Flames);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.timeLeft = 60;
            projectile.scale = 3.25f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.light = 2.5f;
        }

        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit) {
            target.AddBuff (BuffID.OnFire, 300);
        }

        public override void OnHitPlayer (Player target, int damage, bool crit) {
            target.AddBuff (BuffID.OnFire, 300);
        }

        public override void OnHitPvp (Player target, int damage, bool crit) {
            target.AddBuff (BuffID.OnFire, 300);
        }
        public override void Kill (int timeLeft) {

            if (Main.rand.Next (1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust (new Vector2 (projectile.Center.X, projectile.Center.Y - 15), 10, 10, DustID.Smoke, 0, -5);
                Main.dust[dust].scale *= 1f + Main.rand.NextFloat ();
                Main.dust[dust].noGravity = true;
            }
            int pro = Projectile.NewProjectile (projectile.position.X, projectile.position.Y, 0, 0, ModContent.ProjectileType<Projectiles.TorchLightProj> (), 0, 0);
        }
    }
}