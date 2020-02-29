using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class FlameStormProj : ModProjectile {

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
            projectile.timeLeft = 40;
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
                int dust = Dust.NewDust(new Vector2(projectile.Center.X +45, projectile.Center.Y), projectile.width, projectile.height, 35);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
                int dust2 = Dust.NewDust(new Vector2(projectile.Center.X +90, projectile.Center.Y), projectile.width, projectile.height, 35);
                Main.dust[dust2].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust2].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust2].noGravity = true;
                int dust3 = Dust.NewDust(new Vector2(projectile.Center.X -55, projectile.Center.Y), projectile.width, projectile.height, 35);
                Main.dust[dust3].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust3].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust3].noGravity = true;
                int dust4 = Dust.NewDust(new Vector2(projectile.Center.X -110, projectile.Center.Y), projectile.width, projectile.height, 35);
                Main.dust[dust4].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust4].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust4].noGravity = true;
                if (projectile.timeLeft <= 30) {
                    if (projectile.ai[1] == 1) {
                        //projectile.height = 10;
                        //projectile.position.Y -= 5;
                        projectile.ai[1] = 2;
                    }
                    if (projectile.timeLeft == 30 || projectile.timeLeft == 25 || projectile.timeLeft == 20 || projectile.timeLeft == 15 || projectile.timeLeft == 10 || projectile.timeLeft == 5){
                    int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X +50, projectile.Center.Y), new Vector2(0, -3.5f), ProjectileID.Flames, projectile.damage, 0.25f, projectile.owner);
                    int proj2 = Projectile.NewProjectile(new Vector2(projectile.Center.X +100, projectile.Center.Y), new Vector2(0, -3.5f), ProjectileID.Flames, projectile.damage, 0.25f, projectile.owner);
                    int proj3 = Projectile.NewProjectile(new Vector2(projectile.Center.X -50, projectile.Center.Y), new Vector2(0, -3.5f), ProjectileID.Flames, projectile.damage, 0.25f, projectile.owner);
                    int proj4 = Projectile.NewProjectile(new Vector2(projectile.Center.X -100, projectile.Center.Y), new Vector2(0, -3.5f), ProjectileID.Flames, projectile.damage, 0.25f, projectile.owner);
                    
                    
                    
                     }
                    return;
                }
            } else {
                projectile.velocity.Y = 30;
                projectile.timeLeft = 50;
            }
        }
    }
}