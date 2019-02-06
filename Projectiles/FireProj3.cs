using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class FireProj3 : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_14"; } }

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 4;
            DisplayName.SetDefault("Black Fire");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.BlackBolt);
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.magic = true;
            projectile.timeLeft = 30;
            projectile.scale = 1.5f;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
        }
                public override void AI() {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 10, 0, 0, 0, Color.Black, 3f);
            Main.dust[dust].velocity *= 0.3f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, 0, 0, 0, Color.White, 2f);
            Main.dust[dust2].velocity *= 0.3f + Main.rand.NextFloat();
            Main.dust[dust2].scale *= 0.25f + Main.rand.NextFloat();
            Main.dust[dust2].noGravity = true;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }

        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }
    }
}