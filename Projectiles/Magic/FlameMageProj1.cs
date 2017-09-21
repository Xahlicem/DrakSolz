using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class FlameMageProj1 : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
            Main.projHostile[projectile.type] = false;
        }

        public override string Texture { get { return "DrakSolz/Projectiles/Magic/SorcSwordProj"; } }

        public override void SetDefaults() {
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 24;
            projectile.height = 10;
            projectile.timeLeft = 60;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.ai[1] = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.ai[1] = 1;
            return false;
        }

        public override void AI() {
            projectile.ai[0]++;
            if (projectile.ai[1] == 1) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 35);
                Main.dust[dust].velocity *= 0f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            } else {
                projectile.velocity.Y = 30;
                projectile.timeLeft = 60;
            }
        }

        public override void Kill(int timeLeft) {
            int proj = Projectile.NewProjectile(projectile.Center, new Vector2(0, -2), ProjectileID.DD2OgreStomp, projectile.damage, 0.5f, projectile.owner);
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
        }
    }
 }