using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace XahlicemMod.Projectiles
{
    public class MGSProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            //ProjectileID.Sets.Homing[projectile.type] = false;
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.TerraBladeBeam);
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 25;
            projectile.height = 7;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
        }

        public override void AI()
        {

            projectile.frame = (int)projectile.localAI[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(90f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }


        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = 0;
                switch ((int)projectile.ai[1])
                {
                    case 1:
                    case 2:
                        dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1);
                        break;
                    case 3:
                        dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                        break;
                    case 4:
                        dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74);
                        break;
                }
                
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 1.2f)
            {
                vector *= 60f / magnitude;
            }
        }

    }
}
