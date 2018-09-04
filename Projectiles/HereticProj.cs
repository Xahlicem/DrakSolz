using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class HereticProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_641"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton's Bone");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(641);
            projectile.aiStyle = 2;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;
        }

        public override void AI() {
            projectile.ai[0]++;
            if (projectile.ai[1] != 0) {
                projectile.velocity.Y = 0;
                projectile.velocity.X = 0;
                if (projectile.timeLeft <= 20) {

                    if (projectile.timeLeft == 150 || projectile.timeLeft == 120 || projectile.timeLeft == 90 || projectile.timeLeft == 60 || projectile.timeLeft == 30){
                        Vector2 mouse = new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y);
                mouse = mouse - projectile.Center;
                DrakSolz.AdjustMagnitude(ref mouse, 18f);
                    int proj = Projectile.NewProjectile(projectile.Center, mouse, ProjectileID.Flames, projectile.damage, 3.5f, projectile.owner);
                    Main.projectile[proj].magic = true;
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].friendly = true;
                     }
                    return;
                }
            }
        }
    }
}