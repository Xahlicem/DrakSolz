using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {
    public class Obelysk : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Obelysk");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.scale = 1;
            npc.width = 48;
            npc.height = 60;
            npc.damage = 0;
            npc.defense = 1500;
            npc.lifeMax = 100000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0;
            npc.aiStyle = -1;
            npc.localAI[0] = 0f;
            npc.localAI[1] = 0f;
            npc.localAI[2] = 0f;
            npc.localAI[3] = 0f;
            npc.ai[3] = -1f;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Spell_Time_Slot = 2;

        const int State_Spell = 1;

        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float AI_SpellTime {
            get { return npc.ai[AI_Spell_Time_Slot]; }
            set { npc.ai[AI_Spell_Time_Slot] = value; }
        }

        public override void AI() {
            npc.TargetClosest(true);
            AI_Timer++;
            if (AI_Timer == 450) {
                npc.TargetClosest(true);
                Vector2 speed = Main.player[npc.target].Center - npc.Center;
                DrakSolz.AdjustMagnitude(ref speed, 7.5f);
                int pro = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, speed.X * 1.4f, speed.Y * 1.4f, ModContent.ProjectileType<Projectiles.DervishWind>(), npc.damage, 3f);
                Main.projectile[pro].friendly = false;
                Main.projectile[pro].hostile = true;
                Main.projectile[pro].tileCollide = false;
                Main.projectile[pro].timeLeft = 1;

            }
            if (AI_Timer >= 600) {
                AI_Timer = 0;
            }
        }

        const int Frame_Still = 0;
        const int Frame_Still_1 = 1;
        const int Frame_Still_2 = 2;
        const int Frame_Still_3 = 3;
        const int Frame_Still_4 = 4;
        const int Frame_Still_5 = 5;
        const int Frame_Still_6 = 6;
        const int Frame_Still_7 = 7;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter < 8) {
                npc.frame.Y = Frame_Still * frameHeight;
            } else if (npc.frameCounter < 16) {
                npc.frame.Y = Frame_Still_1 * frameHeight;
            } else if (npc.frameCounter < 24) {
                npc.frame.Y = Frame_Still_2 * frameHeight;
            } else if (npc.frameCounter < 32) {
                npc.frame.Y = Frame_Still_3 * frameHeight;
            } else if (npc.frameCounter < 40) {
                npc.frame.Y = Frame_Still_4 * frameHeight;
            } else if (npc.frameCounter < 48) {
                npc.frame.Y = Frame_Still_5 * frameHeight;
            } else if (npc.frameCounter < 56) {
                npc.frame.Y = Frame_Still_6 * frameHeight;
            } else if (npc.frameCounter < 64) {
                npc.frame.Y = Frame_Still_7 * frameHeight;

            } else {
                npc.frameCounter = 0;
            }
        }
    }
}