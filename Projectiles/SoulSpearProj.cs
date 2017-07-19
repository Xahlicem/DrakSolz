using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Projectiles {
    public class SoulSpearProj : ModProjectile {

        public override void SetStaticDefaults() {
            ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 1;
            Main.projHostile[projectile.type] = true;
        }

        public override void SetDefaults() {
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 24;
            projectile.height = 24;
            projectile.timeLeft = 150;
            projectile.penetrate = 1;
        }

        /*public override void OnHitPlayer (Player target, int damage, bool crit) {
            projectile.Kill ();
        }*/

        public override void AI() {
            projectile.ai[0]++;
            if (projectile.owner == 255) {
                projectile.hostile = true;
                projectile.friendly = false;
            } else {
                projectile.hostile = false;
                projectile.friendly = true;
            }
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            if (projectile.localAI[0] <= 0f) {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1.9f;
            }

            projectile.localAI[0] -= 0.1f;
            Vector2 move = Vector2.Zero;
            float distance = 225f;
            bool target = false;

            if (projectile.ai[0] <= 30)
                if (projectile.owner == 255)
                    for (int k = 0; k < 200; k++) {
                        if (Main.player[k].active && CanHitPlayer(Main.player[k])) {
                            Vector2 newMove = Main.player[k].Center - projectile.Center;
                            float distanceTo = (float) Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);

                            if (distanceTo < distance) {
                                move = newMove;
                                distance = distanceTo;
                                target = true;
                            }
                        }
                    }
            else
                for (int k = 0; k < 200; k++) {
                    NPC targetNPC = Main.npc[k];
                    if (targetNPC.active && !targetNPC.dontTakeDamage && !targetNPC.friendly) {
                        Vector2 newMove = targetNPC.Center - projectile.Center;
                        float distanceTo = (float) Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);

                        if (projectile.AI_137_CanHit(targetNPC.Center) && distanceTo < distance && targetNPC.FindBuffIndex(BuffID.BrokenArmor) == -1) {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }

            if (target) {
                AdjustMagnitude(ref move);
                projectile.velocity = (25 * projectile.velocity + move) / 26f;
                AdjustMagnitude(ref projectile.velocity);
            }
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight);
            Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
        }

        public override void Kill(int timeLeft) {
            for (int i = 0; i < 50; i++) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 9f) {
                vector *= 9f / magnitude;
            }
        }

    }
}