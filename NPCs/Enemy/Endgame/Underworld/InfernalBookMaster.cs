using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Underworld {
    public class InfernalBookMaster : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Infernal Heretic");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.scale = 0.8f;
            npc.width = 48;
            npc.height = 60;
            npc.damage = 70;
            npc.defense = 1700;
            npc.lifeMax = 45000;
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
            if (AI_Timer == 90 ) {
                npc.TargetClosest(true);
                Vector2 speed = Main.player[npc.target].Center - npc.Center;
                DrakSolz.AdjustMagnitude(ref speed, 7.5f);
                int pro = Projectile.NewProjectile(npc.Center.X + (30 * npc.direction), npc.Center.Y - 25, speed.X * 1.4f, speed.Y * 1.4f, ProjectileID.Fireball, npc.damage, 3f);
                Main.projectile[pro].friendly = false;
                Main.projectile[pro].hostile = true;
                Main.projectile[pro].tileCollide = false;

            }
            if (AI_Timer >= 100) {
                AI_Timer = 0;
            }
        }
        const int Frame_Spell = 0;
        const int Frame_Spell_2 = 1;
        const int Frame_Spell_3 = 2;
        const int Frame_Spell_4 = 3;
        const int Frame_Spell_5 = 4;
        const int Frame_Spell_6 = 5;
        const int Frame_Spell_7 = 6;
        const int Frame_Spell_8 = 7;
        const int Frame_Spell_9 = 8;
        const int Frame_Spell_10 = 9;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter < 5) {
                npc.frame.Y = Frame_Spell * frameHeight;
            } else if (npc.frameCounter < 10) {
                npc.frame.Y = Frame_Spell_2 * frameHeight;
            } else if (npc.frameCounter < 15) {
                npc.frame.Y = Frame_Spell_3 * frameHeight;
            } else if (npc.frameCounter < 20) {
                npc.frame.Y = Frame_Spell_4 * frameHeight;
            } else if (npc.frameCounter < 25) {
                npc.frame.Y = Frame_Spell_5 * frameHeight;
            } else if (npc.frameCounter < 30) {
                npc.frame.Y = Frame_Spell_6 * frameHeight;
            } else if (npc.frameCounter < 35) {
                npc.frame.Y = Frame_Spell_7 * frameHeight;
            } else if (npc.frameCounter < 40) {
                npc.frame.Y = Frame_Spell_8 * frameHeight;
            } else if (npc.frameCounter < 45) {
                npc.frame.Y = Frame_Spell_9 * frameHeight;
            } else if (npc.frameCounter < 50) {
                npc.frame.Y = Frame_Spell_10 * frameHeight;

            } else {
                npc.frameCounter = 0;
            }
        }
    }
}