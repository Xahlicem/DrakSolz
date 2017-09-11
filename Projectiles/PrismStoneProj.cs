using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Projectiles {
    public class PrismStoneProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Prism Stone");
        }

        public override void SetDefaults() {
            projectile.ai[1] = 0;
            projectile.scale = 0.5f;
            projectile.tileCollide = true;
            projectile.width = 5;
            projectile.height = 5;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            projectile.alpha = 255;
            return false;
        }

        private const float maxTicks = 20f;
        public override void AI() {
            if (projectile.ai[1] == 0) {
                projectile.ai[1] = BitConverter.ToSingle(new byte[] {
                    (byte) Main.DiscoR, (byte) Main.DiscoG, (byte) Main.DiscoB, 255
                }, 0);
            }

            byte[] rgba = BitConverter.GetBytes(projectile.ai[1]);
            Lighting.AddLight(projectile.position, rgba[0] * 0.025f, rgba[1] * 0.025f, rgba[2] * 0.025f);
            for (int i = 0; i < 1; i++) {
                int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66);
                Dust currentDust = Main.dust[dustIndex];
                currentDust.position = (currentDust.position + projectile.Center) / 2f;
                currentDust.velocity *= 1.5f;
                currentDust.noGravity = true;
                currentDust.color = new Color(rgba[0], rgba[1], rgba[2], rgba[3]);
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= maxTicks) {
                float velXmult = 0.98f;
                float velYmult = 0.35f;
                projectile.ai[0] = maxTicks;
                projectile.velocity.X = projectile.velocity.X * velXmult;
                projectile.velocity.Y = projectile.velocity.Y + velYmult;
            }
        }
    }
}