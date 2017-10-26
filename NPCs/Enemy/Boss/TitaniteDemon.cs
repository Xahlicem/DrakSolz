using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Boss {
    // This ModNPC serves as an example of a complete AI example.
    public class TitaniteDemon : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanite Demon");
            Main.npcFrameCount[npc.type] = 21; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults() {
            npc.width = 32;
            npc.scale *= 3;
            npc.height = 32;
            npc.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1.
            npc.damage = 700;
            npc.defense = 125;
            npc.lifeMax = 20000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 1500000f;
            npc.knockBackResist = 0.0f;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            // we would like this npc to spawn in the overworld.
            return SpawnCondition.DungeonGuardian.Chance * 0.8f;
        }

        // These const ints are for the benefit of the programmer. Organization is key to making an AI that behaves properly without driving you crazy.
        // Here I lay out what I will use each of the 4 npc.ai slots for.
        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Flutter_Time_Slot = 2;
        const int AI_Unused_Slot_3 = 3;

        // npc.localAI will also have 4 float variables available to use. With ModNPC, using just a local class member variable would have the same effect.
        const int Local_AI_Unused_Slot_0 = 0;
        const int Local_AI_Unused_Slot_1 = 1;
        const int Local_AI_Unused_Slot_2 = 2;
        const int Local_AI_Unused_Slot_3 = 3;

        // Here I define some values I will use with the State slot. Using an ai slot as a means to store "state" can simplify things greatly. Think flowchart.
        const int State_Still = 0;
        const int State_Walk = 1;
        const int State_RangeAttack = 2;
        const int State_Attack = 3;
        const int State_Jump = 4;
        const int State_Fall = 5;

        // This is a property (https://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx), it is very useful and helps keep out AI code clear of clutter.
        // Without it, every instance of "AI_State" in the AI code below would be "npc.ai[AI_State_Slot]". 
        // Also note that without the "AI_State_Slot" defined above, this would be "npc.ai[0]".
        // This is all to just make beautiful, manageable, and clean code.
        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        // AdvancedFlutterSlime will need: float in water, diminishing aggo, spawn projectiles.

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI() {
            // The npc starts in the asleep state, waiting for a player to enter range
            if (AI_State == State_Walk) {
                // TargetClosest sets npc.target to the player.whoAmI of the closest player. the faceTarget parameter means that npc.direction will automatically be 1 or -1 if the targetted player is to the right or left. This is also automatically flipped if npc.confused
                npc.TargetClosest(true);

                // Now we check the make sure the target is still valid and within our specified notice range (500)
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 150f) {
                    // Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
                    AI_State = State_Still;
                    AI_Timer = 0;
                }
            }
            // In this state, a player has been targeted
            else if (AI_State == State_Still) {
                /// If the targeted player is in attack range (250).
                if (Main.player[npc.target].Distance(npc.Center) < 100f) {
                    // Here we use our Timer to wait .33 seconds before actually jumping. In FindFrame you'll notice AI_Timer also being used to animate the pre-jump crouch
                    AI_Timer++;
                    if (AI_Timer >= 20) {
                        AI_State = State_Jump;
                        AI_Timer = 0;
                    }
                } else {
                    npc.TargetClosest(true);
                    if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 150f) {
                        // Out targetted player seems to have left our range, so we'll go back to sleep.
                        AI_State = State_Walk;
                        AI_Timer = 0;
                    }
                }
            }
            // In this state, we are in the jump. 
            else if (AI_State == State_Jump) {
                AI_Timer++;
                if (AI_Timer == 1) {
                    // We apply an initial velocity the first tick we are in the Jump frame. Remember that -Y is up. 
                    npc.velocity = new Vector2(npc.direction * 2, -10f);
                } else if (AI_Timer > 40) {
                    // after .66 seconds, we go to the hover state. // TODO, gravity?
                    AI_State = State_Fall;
                    AI_Timer = 0;
                }
            }
            // In this state, our npc starts to flutter/fly a little to make it's movement a little bit interesting.
            else if (AI_State == State_Attack) {

            }
            // In this state, we fall untill we hit the ground. Since npc.noTileCollide is false, our npc collides with ground it lands on and will have a zero y velocity once it has landed.
            else if (AI_State == State_Fall) {
                if (npc.velocity.Y == 0) {
                    npc.velocity.X = 0;
                    AI_State = State_Still;
                    AI_Timer = 0;
                }
            }
        }

        // Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
        const int Frame_Still = 0;
        const int Frame_Walk_1 = 10;
        const int Frame_Walk_2 = 11;
        const int Frame_Walk_3 = 12;
        const int Frame_Walk_4 = 13;
        const int Frame_Walk_5 = 14;
        const int Frame_Walk_6 = 1;
        const int Frame_Walk_7 = 2;
        const int Frame_Walk_8 = 3;
        const int Frame_Walk_9 = 4;
        const int Frame_Walk_10 = 5;
        const int Frame_Walk_11 = 6;
        const int Frame_Walk_12 = 7;
        const int Frame_Walk_13 = 8;
        const int Frame_Walk_14 = 9;
        const int Frame_Attack_1 = 15;
        const int Frame_Attack_2 = 16;
        const int Frame_Attack_3 = 17;
        const int Frame_Attack_4 = 18;

        const int Frame_Jump = 19;
        const int Frame_Falling = 20;

        // Here in FindFrame, we want to set the animation frame our npc will use depending on what it is doing.
        // We set npc.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convinience, I have defined some consts above.
        public override void FindFrame(int frameHeight) {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.spriteDirection = npc.direction;

            // For the most part, our animation matches up with our states.
            if (AI_State == State_Still) {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                npc.frame.Y = Frame_Still * frameHeight;
            } else if (AI_State == State_Jump) {
                // Going from Notice to Asleep makes our npc look like it's crouching to jump.
                if (AI_Timer < 10) {
                    npc.frame.Y = Frame_Still * frameHeight;
                } else {
                    npc.frame.Y = Frame_Jump * frameHeight;
                }
            } else if (AI_State == State_Walk) {
                // Here we have 3 frames that we want to cycle through.
                npc.frameCounter++;
                if (npc.frameCounter < 3) {
                    npc.frame.Y = Frame_Walk_1 * frameHeight;
                } else if (npc.frameCounter < 6) {
                    npc.frame.Y = Frame_Walk_2 * frameHeight;
                } else if (npc.frameCounter < 9) {
                    npc.frame.Y = Frame_Walk_3 * frameHeight;
                    if (Math.Abs(npc.velocity.X) < 2) {
                        npc.velocity = new Vector2(npc.direction * 0, 0);
                    }
                } else if (npc.frameCounter < 12) {
                    npc.frame.Y = Frame_Walk_4 * frameHeight;
                } else if (npc.frameCounter < 15) {
                    npc.frame.Y = Frame_Walk_5 * frameHeight;
                } else if (npc.frameCounter < 18) {
                    npc.frame.Y = Frame_Walk_6 * frameHeight;
                } else if (npc.frameCounter < 21) {
                    npc.frame.Y = Frame_Walk_7 * frameHeight;
                } else if (npc.frameCounter < 24) {
                    npc.frame.Y = Frame_Walk_8 * frameHeight;
                } else if (npc.frameCounter < 27) {
                    npc.frame.Y = Frame_Walk_9 * frameHeight;
                } else if (npc.frameCounter < 30)

                {
                    npc.frame.Y = Frame_Walk_10 * frameHeight;
                } else if (npc.frameCounter < 36) {
                    npc.frame.Y = Frame_Walk_11 * frameHeight;
                    if (Math.Abs(npc.velocity.X) < 2) {
                        npc.velocity = new Vector2(npc.direction * 1f, 0);
                    }
                } else if (npc.frameCounter < 42) {
                    npc.frame.Y = Frame_Walk_12 * frameHeight;
                } else if (npc.frameCounter < 48) {
                    npc.frame.Y = Frame_Walk_13 * frameHeight;
                    if (Math.Abs(npc.velocity.X) < 2) {
                        npc.velocity = new Vector2(npc.direction * 1.5f, 0);
                    }
                } else if (npc.frameCounter < 54) {
                    npc.frame.Y = Frame_Walk_14 * frameHeight;
                } else {
                    npc.frameCounter = 0;
                }
            } else if (AI_State == State_Fall) {
                npc.frame.Y = Frame_Falling * frameHeight;
            }
        }
    }
}