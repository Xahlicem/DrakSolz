using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Boss {
    public class AbyssStalker : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Abyss Stalker");
            Main.npcFrameCount[npc.type] = 24;
        }

        public override void SetDefaults() {
            npc.width = 30;
            npc.scale = 2;
            npc.height = 45;
            npc.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1.
            npc.damage = 350;
            npc.defense = 1700;
            npc.lifeMax = 750000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 50000f;
            npc.altTexture = 1;
            npc.knockBackResist = 0f;
            npc.buffImmune[BuffID.Confused] = true;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Falling_Slot = 2;
        const int AI_Away_Slot = 3;

        const int State_Still = 0;
        const int State_Walk = 1;
        const int State_Attack = 2;
        const int State_Jump = 3;
        const int State_Falling = 4;
        const int State_Fallen = 5;

        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }
        public float AI_Falling_Timer {
            get { return npc.ai[AI_Falling_Slot]; }
            set { npc.ai[AI_Falling_Slot] = value; }
        }
        public float AI_Away_Timer {
            get { return npc.ai[AI_Away_Slot]; }
            set { npc.ai[AI_Away_Slot] = value; }
        }

        // AdvancedFlutterSlime will need: float in water, diminishing aggo, spawn projectiles.

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI() {
            if (npc.velocity.Y > 2f) {
                AI_Falling_Timer++;
                if (AI_Falling_Timer >= 15) {
                    AI_State = State_Falling;
                    AI_Falling_Timer = 0;
                }
            } else AI_Falling_Timer = 0;
            // The npc starts in the asleep state, waiting for a player to enter range
            if (AI_State == State_Still) {

                // TargetClosest sets npc.target to the player.whoAmI of the closest player. the faceTarget parameter means that npc.direction will automatically be 1 or -1 if the targetted player is to the right or left. This is also automatically flipped if npc.confused
                npc.TargetClosest(true);

                // Now we check the make sure the target is still valid and within our specified notice range (500)
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 1050f) {
                    // Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
                    AI_State = State_Walk;
                    AI_Timer = 0;
                } else if (npc.life < npc.lifeMax) {
                    AI_Timer++;
                    if (AI_Timer >= 10) {
                        AI_State = State_Walk;
                        AI_Timer = 0;
                    }
                }
            } else if (AI_State == State_Walk) {
                AI_Away_Timer++;
                AI_Timer = 0;
                npc.TargetClosest();
                npc.velocity.X = npc.direction * (9 - ((npc.life + 1) / 187500));
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 80f) {
                    npc.velocity.X = 0;
                    AI_Away_Timer = 0;
                    if (npc.life <= 600000 && npc.life > 300000) {
                        if (Main.netMode != 1) {
                            if (Main.rand.Next(5) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.StalkerProj>(), npc.damage / 10, 1f);
                        }

                    }
                    if (npc.life <= 300000 && npc.life > 100000) {
                        if (Main.netMode != 1) {
                            if (Main.rand.Next(2) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.StalkerProj>(), npc.damage / 10, 1f);
                        }

                    }
                    if (npc.life <= 100000) {
                        if (Main.netMode != 1) {
                            if (Main.rand.Next(1) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.StalkerProj>(), npc.damage / 10, 1f);
                        }

                    }
                    AI_State = State_Attack;
                    npc.frameCounter = 0;
                }
                if ((npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) > 500f) || AI_Away_Timer >= 80) {
                    if (npc.life <= 600000 && npc.life > 300000) {
                        if (Main.netMode != 1) {
                            if (Main.rand.Next(5) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.StalkerProj>(), npc.damage / 10, 1f);
                        }

                    }
                    if (npc.life <= 300000 && npc.life > 100000) {
                        if (Main.netMode != 1) {
                            if (Main.rand.Next(2) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.StalkerProj>(), npc.damage / 10, 1f);
                        }

                    }
                    if (npc.life <= 100000) {
                        if (Main.netMode != 1) {
                            if (Main.rand.Next(1) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.StalkerProj>(), npc.damage / 10, 1f);
                        }

                    }
                    AI_State = State_Jump;
                    AI_Away_Timer = 0;
                }
            } else if (AI_State == State_Jump) {
                AI_Timer++;
                if (npc.velocity.Y >= 1f) AI_State = State_Falling;
                if (AI_Timer == 12) {
                    npc.velocity.Y -= 10f;
                    npc.TargetClosest();
                } else if (AI_Timer >= 45) {
                    AI_State = State_Falling;
                    AI_Timer = 0;
                } else npc.velocity.X = (Main.player[npc.target].position.X - npc.position.X) / 60;

            } else if (AI_State == State_Falling) {
                if (npc.velocity.Y == 0f) {
                    npc.velocity.X = 0;
                    AI_State = State_Fallen;
                    AI_Timer = 0;
                }
            } else if (AI_State == State_Fallen) {
                AI_Timer++;
                if (AI_Timer == 1)
                    if (Main.netMode != 1) {
                        int proj = Projectile.NewProjectile(npc.Center, GetVelocity(Main.player[npc.target]), ProjectileID.DD2OgreSmash, npc.damage * 1, 2f);
                        Main.projectile[proj].alpha = 255;
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                    }
                if (AI_Timer >= 20) {
                    AI_State = State_Walk;
                    AI_Timer = 0;
                }

            } else if (AI_State == State_Attack) {
                AI_Timer++;
                if (AI_Timer == 20)
                    if (Main.netMode != 1) {
                        int proj = Projectile.NewProjectile(npc.Center, GetVelocity(Main.player[npc.target]), ProjectileID.Boulder, npc.damage * 2, 2f);
                        Main.projectile[proj].alpha = 255;
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                        Main.projectile[proj].timeLeft = 5;
                    }
                if (AI_Timer >= 50) {
                    AI_State = State_Walk;
                    AI_Timer = 0;
                }

            }

        }

        // Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
        const int Frame_Still = 0;
        const int Frame_Walk_1 = 1;
        const int Frame_Walk_2 = 2;
        const int Frame_Walk_3 = 3;
        const int Frame_Walk_4 = 4;
        const int Frame_Walk_5 = 5;
        const int Frame_Walk_6 = 6;
        const int Frame_Walk_7 = 7;
        const int Frame_Walk_8 = 8;
        const int Frame_Attack_1 = 9;
        const int Frame_Attack_2 = 10;
        const int Frame_Attack_3 = 11;
        const int Frame_Attack_4 = 12;
        const int Frame_Attack_5 = 13;
        const int Frame_Attack_6 = 14;
        const int Frame_Attack_7 = 15;
        const int Frame_Attack_8 = 16;
        const int Frame_Attack_9 = 17;
        const int Frame_Attack_10 = 18;
        const int Frame_Jump_1 = 19;
        const int Frame_Jump_2 = 20;
        const int Frame_Jump_3 = 21;
        const int Frame_Jump_4 = 22;
        const int Frame_Jump_5 = 23;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;

            if (AI_State == State_Still) {
                npc.frame.Y = Frame_Still * frameHeight;
                npc.velocity = new Vector2(npc.direction * 0, 0);
            } else if (AI_State == State_Fallen) {
                npc.frameCounter++;
                if (npc.frameCounter < 4) {
                    npc.frame.Y = Frame_Jump_5 * frameHeight;
                } else if (npc.frameCounter < 8) {
                    npc.frame.Y = Frame_Attack_7 * frameHeight;
                } else if (npc.frameCounter < 12) {
                    npc.frame.Y = Frame_Attack_8 * frameHeight;
                } else if (npc.frameCounter < 16) {
                    npc.frame.Y = Frame_Attack_9 * frameHeight;
                } else if (npc.frameCounter < 20) {
                    npc.frame.Y = Frame_Attack_10 * frameHeight;
                } else {
                    npc.frameCounter = 0;
                }
            } else if (AI_State == State_Falling) {
                npc.frame.Y = Frame_Jump_4 * frameHeight;
                npc.frameCounter = 0;
            } else if (AI_State == State_Attack) {
                npc.frameCounter++;
                if (npc.frameCounter < 5) {
                    npc.frame.Y = Frame_Attack_1 * frameHeight;
                } else if (npc.frameCounter < 10) {
                    npc.frame.Y = Frame_Attack_2 * frameHeight;
                } else if (npc.frameCounter < 15) {
                    npc.frame.Y = Frame_Attack_3 * frameHeight;
                } else if (npc.frameCounter < 20) {
                    npc.frame.Y = Frame_Attack_4 * frameHeight;
                } else if (npc.frameCounter < 25) {
                    npc.frame.Y = Frame_Attack_5 * frameHeight;
                } else if (npc.frameCounter < 30) {
                    npc.frame.Y = Frame_Attack_6 * frameHeight;
                } else if (npc.frameCounter < 35) {
                    npc.frame.Y = Frame_Attack_7 * frameHeight;
                } else if (npc.frameCounter < 40) {
                    npc.frame.Y = Frame_Attack_8 * frameHeight;
                } else if (npc.frameCounter < 45) {
                    npc.frame.Y = Frame_Attack_9 * frameHeight;
                } else if (npc.frameCounter < 50) {
                    npc.frame.Y = Frame_Attack_10 * frameHeight;
                } else {
                    npc.frameCounter = 0;
                }
            } else if (AI_State == State_Jump) {
                npc.frameCounter++;
                if (npc.frameCounter < 5) {
                    npc.frame.Y = Frame_Jump_1 * frameHeight;
                } else if (npc.frameCounter < 10) {
                    npc.frame.Y = Frame_Jump_2 * frameHeight;
                } else if (npc.frameCounter < 15) {
                    npc.frame.Y = Frame_Jump_3 * frameHeight;
                } else if (npc.frameCounter < 55) {
                    npc.frame.Y = Frame_Jump_4 * frameHeight;
                }
            } else if (AI_State == State_Walk) {
                npc.frameCounter++;
                if (npc.frameCounter < 4) {
                    npc.frame.Y = Frame_Walk_1 * frameHeight;
                } else if (npc.frameCounter < 8) {
                    npc.frame.Y = Frame_Walk_2 * frameHeight;
                } else if (npc.frameCounter < 12) {
                    npc.frame.Y = Frame_Walk_3 * frameHeight;
                    if (Math.Abs(npc.velocity.X) < 1) {
                        npc.velocity.Y -= 1f;
                    }
                } else if (npc.frameCounter < 16) {
                    npc.frame.Y = Frame_Walk_4 * frameHeight;
                } else if (npc.frameCounter < 20) {
                    npc.frame.Y = Frame_Walk_5 * frameHeight;
                } else if (npc.frameCounter < 24) {
                    npc.frame.Y = Frame_Walk_6 * frameHeight;
                } else if (npc.frameCounter < 28) {
                    npc.frame.Y = Frame_Walk_7 * frameHeight;
                } else if (npc.frameCounter < 32) {
                    npc.frame.Y = Frame_Walk_8 * frameHeight;
                } else {
                    npc.frameCounter = 0;
                }
            }
            if (npc.frame.Y == Frame_Jump_4 * frameHeight)
                npc.rotation += npc.direction == 1 ? 0.5f : -0.5f;
            else npc.rotation = 0;
        }

        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 27f / magnitude;

            return vector;
        }
    }
}