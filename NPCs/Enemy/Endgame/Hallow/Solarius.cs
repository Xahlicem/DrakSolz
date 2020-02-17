using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Hallow {
    public class Solarius : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Solarius");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.scale = 1;
            npc.width = 48;
            npc.height = 60;
            npc.damage = 80;
            npc.defense = 1700;
            npc.lifeMax = 45000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HolyBanners.SolariusBanner>();
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
            if (AI_Timer == 100) {
                npc.TargetClosest(true);
                Vector2 speed = Main.player[npc.target].Center - npc.Center;
                DrakSolz.AdjustMagnitude(ref speed, 7.5f);
                int pro = Projectile.NewProjectile(npc.Center.X + (10 * npc.direction), npc.Center.Y - 25, speed.X * 1.4f, speed.Y * 1.4f, ProjectileID.DiamondBolt, npc.damage, 3f);
                Main.projectile[pro].friendly = false;
                Main.projectile[pro].hostile = true;
                Main.projectile[pro].tileCollide = false;

            }
            if (AI_Timer >= 120) {
                AI_Timer = 0;
            }
        }

        const int Frame_Teleport = 0;
        const int Frame_Spell = 1;
        const int Frame_Spell_2 = 2;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter < 20) {
                npc.frame.Y = Frame_Spell * frameHeight;
            } else if (npc.frameCounter < 40) {
                npc.frame.Y = Frame_Teleport * frameHeight;
            } else if (npc.frameCounter < 60) {
                npc.velocity = new Vector2(0, -1);
                npc.frame.Y = Frame_Spell * frameHeight;
            } else if (npc.frameCounter < 120) {
                npc.frame.Y = Frame_Spell_2 * frameHeight;

            } else {
                npc.frameCounter = 0;
            }
        }
    }
}