using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class FlameMageProj2 : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
        }

        public override string Texture { get { return "DrakSolz/Projectiles/Magic/SorcSwordProj"; } }

        public override void SetDefaults() {
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 24;
            projectile.height = 5;
            projectile.timeLeft = 95;
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
            if (projectile.ai[1] != 0) {
                projectile.velocity.Y = 0;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 35);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
                if (projectile.timeLeft <= 60) {
                    if (projectile.ai[1] == 1) {
                        //projectile.height = 10;
                        //projectile.position.Y -= 5;
                        projectile.ai[1] = 2;
                    }
                    /*int dust2 = Dust.NewDust(new Vector2(projectile.position.Y - 20, projectile.position.X), projectile.width, 10, 35, 0, -50f + Main.rand.NextFloat());
                    Main.dust[dust2].scale *= 1.5f + Main.rand.NextFloat();*/
                    if (projectile.timeLeft == 60 || projectile.timeLeft == 55 || projectile.timeLeft == 50 || projectile.timeLeft == 45 || projectile.timeLeft == 40 ||
                     projectile.timeLeft == 35 || projectile.timeLeft == 30 || projectile.timeLeft == 25 || projectile.timeLeft == 20 || projectile.timeLeft == 15 ||
                     projectile.timeLeft == 10 || projectile.timeLeft == 5){
                    int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y + 10), new Vector2(0, -4f), ProjectileID.Flames, projectile.damage, 0.25f, projectile.owner);
                    Main.projectile[proj].magic = true;
                     }
                    return;
                }
            } else {
                projectile.velocity.Y = 30;
                projectile.timeLeft = 95;
            }
        }
    }
}