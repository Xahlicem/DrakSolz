using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Hallow {
    public class Solpiercer : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Solpiercer");
            Main.npcFrameCount[npc.type] = 12;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.CultistArcherBlue);
            npc.scale = 0.8f;
            npc.width = 60;
            npc.height = 85;
            npc.aiStyle = 3;
            aiType = NPCID.Skeleton;
            animationType = NPCID.CultistArcherBlue;
            npc.damage = 160;
            npc.defense = 1400;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 6000f;
            npc.knockBackResist = 0.07f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HolyBanners.SolpiercerBanner>();
            AI_Timer = 15;
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
            npc.TargetClosest();
            if (npc.HasValidTarget) {
                Vector2 target = Main.player[npc.target].Center;
                target.Y -= 8;
                float dist = npc.Distance(target);
                if (dist < 750 && npc.velocity.Y == 0 && Collision.CanHitLine(npc.Center, 2, 2, target, 4, 4)) {
                    npc.velocity.X = 0;
                    npc.FaceTarget();

                    Angle = MathHelper.ToDegrees(npc.AngleTo(target));

                    Vector2 vector = target - npc.Center;
                    DrakSolz.AdjustMagnitude(ref vector, 12.5f);
                    if (Main.netMode != 1 && AI_Timer > 90) {
                        int proj = Projectile.NewProjectile(npc.Center, vector, ModContent.ProjectileType<Projectiles.LightningArrowProj>(), (int) (npc.damage *0.5), 20);
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                        Main.projectile[proj].timeLeft = 120;
                        Main.projectile[proj].netUpdate = true;

                        AI_Timer = 0;
                    }
                    npc.netUpdate = true;
                } else AI_Timer = 15;
            } else AI_Timer = 15;
            AI_Timer++;
        }

        public int GetFrame(int angle) {
            switch (angle) {
                case 0:
                    return 2;
                case 45:
                    return 1;
                case 90:
                    return 0;
                case 135:
                    return 1;
                case 180:
                    return 2;
                case -180:
                    return 2;
                case -135:
                    return 3;
                case -90:
                    return 4;
                case -45:
                    return 3;
            }
            return 0;
        }

        public override void FindFrame(int frameHeight) {
            if (AI_Timer < 15 || AI_Timer > 50) {
                npc.frame.Y = (GetFrame((int) DrakSolz.RoundToClosest(Angle, 45)) + 2) * frameHeight;
                //Main.NewText(GetFrame((int) angle));
            }
        }
    }
}