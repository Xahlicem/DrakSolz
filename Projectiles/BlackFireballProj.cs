using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class BlackFireballProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Fireball");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Bone);
            projectile.width = 30;
            projectile.height = 30;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.timeLeft = 120;
            projectile.magic = true;
            projectile.thrown = false;
        }
        public override void AI() {
            if (projectile.timeLeft <= 60) {
                projectile.velocity *= 0.98f;
            }
            projectile.scale = 1.0f;
            projectile.alpha = 0;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 10, 0, 0, 0, Color.Black, 3f);
            Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.2f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, 0, 0, 0, Color.White, 2f);
            Main.dust[dust2].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust2].scale *= 0.1f + Main.rand.NextFloat();
            Main.dust[dust2].noGravity = true;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, 600);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, 600);
        }

        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.ShadowFlame, 600);
        }
        public override void Kill(int timeLeft) {

            for (int i = 0; i < projectile.frame * 5 + 5; i++) {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 10, 0, 0, 0, Color.Black, 3f);
                Main.dust[dustIndex].velocity *= 2.5f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 1.0f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, 0f, 0f, 0, Color.White, 2f);
                Main.dust[dustIndex].velocity *= 2.5f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 1.0f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 10, 0, 0, 0, Color.Black, 3f);
                Main.dust[dustIndex].velocity *= 2.5f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 1.0f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, 0f, 0f, 0, Color.White, 2f);
                Main.dust[dustIndex].velocity *= 2.5f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 1.0f;
            }
            int proj = Projectile.NewProjectile(projectile.Center, projectile.velocity * 0, 468, projectile.damage, 0.25f, projectile.owner);
            Main.projectile[proj].magic = true;
            Main.projectile[proj].alpha = 255;
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].scale *= 2;
            Main.projectile[proj].timeLeft = 20;
            Main.projectile[proj].width = 80;
            Main.projectile[proj].height = 80;
            Main.projectile[proj].velocity *= 0f;
        }
    }
}