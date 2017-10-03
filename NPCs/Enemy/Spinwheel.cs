using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class Spinwheel : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spinwheel");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.scale = 1f;
            npc.width = 30;
            npc.height = 68;
            npc.aiStyle = 8;
            aiType = NPCID.Tim;
            animationType = NPCID.Tim;
            npc.damage = 20;
            npc.defense = 9;
            npc.lifeMax = 125;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 225f;
            npc.knockBackResist = 0.1f;
            npc.teleporting = true;
            npc.teleportTime = 2f;
            npc.buffImmune[BuffID.Confused] = true;
            //npc.localAI[0] = 0f;
            //npc.localAI[1] = 0f;
            //npc.localAI[2] = 0f;
            //npc.localAI[3] = 0f;
            //npc.ai[3] = -1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.SpinwheelBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedBoss1)
                return SpawnCondition.Cavern.Chance * 0.08f;
            else return 0f;
        }

        /*const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Dance_Time_Slot = 2;

        const int State_Dance = 0;
        const int State_Spell = 1;
        const int State_Cast = 2;
        const int State_Still = 3;

        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float AI_SpellTime {
            get { return npc.ai[AI_Dance_Time_Slot]; }
            set { npc.ai[AI_Dance_Time_Slot] = value; }
        }

        public override void AI() {
            if (AI_State == State_Dance) {
                AI_Timer++;
                float distance = 1200f;
                Player p;

                for (int k = 0; k < 200; k++) {
                    p = Main.player[k];
                    if (p.active) {
                        if (npc.WithinRange(p.Center, distance)) {

                        }
                    }
                }

                npc.TargetClosest(true);
                if (AI_Timer >= 60) {
                    AI_State = State_Spell;
                    AI_Timer = 0;
                }
            } else if (AI_State == State_Spell) {
                AI_Timer++;
                if (AI_Timer == 10 && Main.netMode != 1) {
                    Vector2 playerpos = Main.player[npc.target].Center;
                    playerpos.Y -= 5;
                    int proj = Projectile.NewProjectile(playerpos, Vector2.Zero, mod.ProjectileType<Projectiles.Magic.FlameMageProj>(), npc.damage, 0f);
                }

                if (AI_Timer >= 120) {
                    AI_Timer = 0;
                    AI_State = State_Dance;
                }
            } else {
                AI_Timer++;
                if (AI_Timer >= 60) {
                    AI_State = State_Dance;
                    AI_Timer = 0;
                }
            }
        }

        const int Frame_Cast = 0;
        const int Frame_Spell = 0;
        const int Frame_Still = 0;
        const int Frame_Dance_Offset = 0;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;

            if (AI_State == State_Cast) {
                npc.frame.Y = Frame_Cast * frameHeight;
            } else if (AI_State == State_Spell) {
                AI_SpellTime++;
                if (AI_SpellTime < 55) {
                    npc.frame.Y = Frame_Spell * frameHeight;
                } else {
                    npc.frame.Y = Frame_Cast * frameHeight;
                }
                if (AI_SpellTime >= 120) {
                    AI_SpellTime = 0;
                }
            } else if (AI_State == State_Dance) {
                if (npc.frameCounter >= 49 - 1) npc.frameCounter = 0;
                else npc.frameCounter++;
                npc.frame.Y = ((int) npc.frameCounter / 10 + Frame_Dance_Offset) * frameHeight;
            } else if (AI_State == State_Still) {
                npc.frame.Y = Frame_Still * frameHeight;

            }
        }
*/
        public override void NPCLoot() {
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Armor.FatherMask>());
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 7.5f / magnitude;

        }
        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 0.01f / magnitude;

            return vector;
        }
    }
}