using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace XahlicemMod.Projectiles
{
    public class SoulSpearProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            //ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.TinyEater);
            projectile.friendly = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 33;
            projectile.height = 110;
            projectile.timeLeft = 30;
        }

        public override void AI()
        {

            projectile.frame = (int)(projectile.localAI[0] * 2f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(90f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            if (projectile.localAI[0] <= 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1.9f;
            }

            projectile.localAI[0] -= 0.1f;
            Vector2 move = Vector2.Zero;
            float distance = 225f;
            bool target = false;

            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);

                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }

            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }

            if (projectile.localAI[0] <= 0.5f)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 28);
                Main.dust[dust].velocity /= 1f + Main.rand.NextFloat();
                Main.dust[dust].scale /= 2f + Main.rand.NextFloat();
            }

        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
                Main.dust[dust].velocity *= Main.rand.NextFloat();
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 9f)
            {
                vector *= 9f / magnitude;
            }
        }

    }
}
