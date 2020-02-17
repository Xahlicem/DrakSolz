using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.NPCs.Enemy.Endgame.Ice {
    public class Nemeton : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Nemeton");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.CaveBat);
            npc.scale = 0.8f;
            npc.width = 30;
            npc.height = 30;
            //npc.aiStyle = 39;
            aiType = NPCID.CaveBat;
            animationType = NPCID.GiantBat;
            npc.damage = 150;
            npc.defense = 1500;
            npc.lifeMax = 60000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.05f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.LittleMushroomBanner>();
        }

        const int AI_Timer_Slot = 3;

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        const int Angle_Slot = 2;

        public float Angle {
            get { return npc.localAI[Angle_Slot]; }
            set { npc.localAI[Angle_Slot] = value; }
        }

        public override void AI() {
            npc.timeLeft = 60;
            npc.TargetClosest();
            if (npc.HasValidTarget) {
                Vector2 target = Main.player[npc.target].Center;
                target.Y -= 8;
                float dist = npc.Distance(target);
                if (dist < 1000)
                    AI_Timer++;
                npc.FaceTarget();

                Angle = MathHelper.ToDegrees(npc.AngleTo(target));

                Vector2 vector = target - npc.Center;
                DrakSolz.AdjustMagnitude(ref vector, 12.5f);
                if (Main.netMode != 1 && AI_Timer > 60) {
                    float numberProjectiles = 2;
                    float rotation = MathHelper.ToRadians(5);
                    for (int i = 0; i < numberProjectiles; i++) {
                        Vector2 perturbedSpeed = new Vector2(vector.X, vector.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                        int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 40, perturbedSpeed.X * 15, perturbedSpeed.Y * 15, ProjectileID.IceBolt, npc.damage, 3);
                        Main.projectile[proj].scale *= 0.8f;
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                        Main.projectile[proj].velocity *= 0.07f;
                    }
                    /*int proj = Projectile.NewProjectile(npc.Center, vector, ModContent.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), npc.damage, 0);
                    Main.projectile[proj].friendly = false;
                    Main.projectile[proj].hostile = true;
                    Main.projectile[proj].netUpdate = true;*/
                    if (Main.netMode != 1 && AI_Timer > 60) {
                        AI_Timer = 0;
                    }
                }
                npc.netUpdate = true;
            }
        }
        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 26.5f / magnitude;

            return vector;
        }
    }
}