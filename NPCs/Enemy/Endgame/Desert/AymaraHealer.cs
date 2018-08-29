using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {
        public class AymaraHealer : ModNPC {
            public override void SetStaticDefaults() {
                DisplayName.SetDefault("Aymara Healer");
                Main.npcFrameCount[npc.type] = 3;
            }

            public override void SetDefaults() {
                npc.scale = 1;
                npc.width = 48;
                npc.height = 60;
                npc.damage = 100;
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
                if (AI_Timer == 280) {
                    float numberProjectiles = 10;
                    float rotation = MathHelper.ToRadians(10);
                    int playerm = npc.target;
                    for (int i = 0; i < numberProjectiles; i++) {
                        int pro = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 15 * (Main.rand.NextFloat() - 0.5f), -15 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.HealProj>(), 10, 1f, playerm);
                        Main.projectile[pro].tileCollide = false;
                        Main.projectile[pro].velocity *= 2;

                    }
                }
                    if (AI_Timer >= 300) {
                        AI_Timer = 0;
                    }
                }

                const int Frame_Teleport = 0;
                const int Frame_Spell = 1;
                const int Frame_Spell_2 = 2;

                public override void FindFrame(int frameHeight) {
                    npc.spriteDirection = npc.direction;
                    npc.frameCounter++;
                    if (npc.frameCounter < 200) {
                        npc.frame.Y = Frame_Spell * frameHeight;
                    } else if (npc.frameCounter < 220) {
                        npc.frame.Y = Frame_Teleport * frameHeight;
                    } else if (npc.frameCounter < 240) {
                        npc.velocity = new Vector2(0, -1);
                        npc.frame.Y = Frame_Spell * frameHeight;
                    } else if (npc.frameCounter < 300) {
                        npc.frame.Y = Frame_Spell_2 * frameHeight;

                    } else {
                        npc.frameCounter = 0;
                    }
                }
            }
        }