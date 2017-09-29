using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class Channeler : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Channeler");
            Main.npcFrameCount[npc.type] = 7;
        }

        public override void SetDefaults() {
            npc.width = 40;
            npc.height = 56;
            npc.aiStyle = -1;
            npc.damage = 25;
            npc.defense = 25;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 25f;
            npc.knockBackResist = 0.0f;
            npc.teleporting = true;
            npc.teleportTime = 2f;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = false;
            npc.localAI[0] = 0f;
            npc.localAI[1] = 0f;
            npc.localAI[2] = 0f;
            npc.localAI[3] = 0f;
            npc.ai[3] = -1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.ChannelerBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.Dungeon.Chance * 0.05f;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Dance_Time_Slot = 2;

        const int State_Dance = 0;
        const int State_Spell = 1;
        const int State_Teleport = 2;
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
                float distance = 800f;
                float closest = 1000f, last = 800f;
                Player p;

                for (int k = 0; k < 200; k++) {
                    p = Main.player[k];
                    if (p.active) {
                        if (npc.WithinRange(p.Center, distance)) {
                            if ((last = npc.Distance(p.Center)) < closest && last >= 150) {
                                closest = last;
                                npc.localAI[0] = p.position.X;
                                npc.localAI[1] = p.position.Y - 24;
                                npc.ai[3] = 1f;
                            }
                            p.AddBuff(BuffID.WitheredArmor, 300);
                            p.AddBuff(BuffID.WitheredWeapon, 300);
                            p.AddBuff(BuffID.WaterCandle, 300);
                        }
                    }
                }

                npc.TargetClosest(true);
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 350f) {
                    AI_State = State_Spell;
                    AI_Timer = 0;
                }
            } else if (AI_State == State_Spell) {
                AI_Timer++;
                if (Main.player[npc.target].Distance(npc.Center) < 100f) {
                    if (AI_Timer >= 60) {
                        AI_State = State_Teleport;
                    }
                } else {
                    npc.TargetClosest(true);
                    if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 350f) {
                        AI_State = State_Dance;
                        AI_Timer = 0;
                    }

                    if (AI_Timer >= 60) {
                        Vector2 speed = Main.player[npc.target].Center - npc.Center;
                        AdjustMagnitude(ref speed);
                        AI_Timer = 0;
                        if (Main.netMode != 1) {
                            Projectile.NewProjectile(npc.Center.X + 6, npc.Center.Y - 16, speed.X, speed.Y, mod.ProjectileType<Projectiles.Magic.SoulSpearProj>(), npc.damage, 0f);
                        }
                    }
                }
            } else if (AI_State == State_Teleport) {
                Vector2 pos;
                if (npc.ai[3] == 1f) pos = new Vector2(npc.localAI[0], npc.localAI[1]);
                else if (npc.ai[3] == 0f && npc.Distance(new Vector2(npc.localAI[2], npc.localAI[3])) >= 150) pos = new Vector2(npc.localAI[2], npc.localAI[3]);
                else pos = new Vector2(npc.position.X + ((Main.rand.NextBool()) ? +200 : -200), npc.position.Y);
                npc.localAI[2] = npc.position.X;
                npc.localAI[3] = npc.position.Y;
                npc.Teleport(pos, 0, 0);
                npc.ai[3] = 0f;
                AI_State = State_Spell;
            } else if (AI_State == State_Still) {
                AI_Timer += 1;
                if (AI_Timer == 1) {
                    AI_SpellTime = 50;
                    npc.netUpdate = true;
                }

                if (AI_Timer > AI_SpellTime) {
                    AI_State = State_Dance;
                    AI_Timer = 0;
                }
            }
        }

        const int Frame_Teleport = 0;
        const int Frame_Spell = 6;
        const int Frame_Dance_1 = 1;
        const int Frame_Dance_2 = 2;
        const int Frame_Dance_3 = 3;
        const int Frame_Dance_4 = 4;
        const int Frame_Dance_5 = 5;
        const int Frame_Dance_6 = 6;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;

            if (AI_State == State_Teleport) {
                npc.frame.Y = Frame_Teleport * frameHeight;
            } else if (AI_State == State_Spell) {
                AI_SpellTime++;
                if (AI_SpellTime < 10) {
                    npc.frame.Y = Frame_Teleport * frameHeight;
                } else {
                    npc.frame.Y = Frame_Spell * frameHeight;
                }
                if (AI_SpellTime >= 60) {
                    AI_SpellTime = 0;
                }
            } else if (AI_State == State_Dance) {
                npc.frameCounter++;
                if (npc.frameCounter < 8) {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                } else if (npc.frameCounter < 16) {
                    npc.frame.Y = Frame_Dance_2 * frameHeight;
                } else if (npc.frameCounter < 24) {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                } else if (npc.frameCounter < 32) {
                    npc.frame.Y = Frame_Dance_2 * frameHeight;
                } else if (npc.frameCounter < 40) {
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                } else if (npc.frameCounter < 48) {
                    npc.frame.Y = Frame_Dance_3 * frameHeight;
                } else if (npc.frameCounter < 56) {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                } else if (npc.frameCounter < 64) {
                    npc.frame.Y = Frame_Dance_5 * frameHeight;
                } else if (npc.frameCounter < 72) {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                } else if (npc.frameCounter < 80) {
                    npc.frame.Y = Frame_Dance_5 * frameHeight;
                } else if (npc.frameCounter < 88) {
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                } else if (npc.frameCounter < 96) {
                    npc.frame.Y = Frame_Dance_6 * frameHeight;
                } else {
                    npc.frameCounter = 0;
                }
            } else if (AI_State == State_Still) {
                npc.frame.Y = Frame_Teleport * frameHeight;

            }
        }

        public override void NPCLoot() {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Channeler_Head"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Channeler_Body"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Channeler_Legs"));

            if (Main.hardMode && Main.rand.Next(4) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.Channeler.ChannelerHelmet>(), mod.ItemType<Items.Armor.Channeler.ChannelerRobe>(), mod.ItemType<Items.Armor.Channeler.ChannelerSkirt>()
                }));
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.ChannelT>());
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 7.5f / magnitude;

        }
    }
}