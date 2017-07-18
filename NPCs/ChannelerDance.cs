using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.NPCs
{
    // This ModNPC serves as an example of a complete AI example.
    public class ChannelerDance : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Channeler");
            Main.npcFrameCount[npc.type] = 7; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 56;
            npc.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1.
            npc.damage = 25;
            npc.defense = 25;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 25f;
            npc.knockBackResist = 0.0f;
            npc.teleporting = true;
            npc.teleportTime = 2f;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
            npc.localAI[0] = 0f;
            npc.localAI[1] = 0f;
            npc.localAI[2] = 0f;
            npc.localAI[3] = 0f;
            npc.ai[3] = -1f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // we would like this npc to spawn in the overworld.
            return SpawnCondition.Overworld.Chance * 5.9f;
        }

        // These const ints are for the benefit of the programmer. Organization is key to making an AI that behaves properly without driving you crazy.
        // Here I lay out what I will use each of the 4 npc.ai slots for.
        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Dance_Time_Slot = 2;
        const int AI_Unused_Slot_3 = 3;

        // npc.localAI will also have 4 float variables available to use. With ModNPC, using just a local class member variable would have the same effect.
        const int Local_AI_Unused_Slot_0 = 0;
        const int Local_AI_Unused_Slot_1 = 1;
        const int Local_AI_Unused_Slot_2 = 2;
        const int Local_AI_Unused_Slot_3 = 3;

        // Here I define some values I will use with the State slot. Using an ai slot as a means to store "state" can simplify things greatly. Think flowchart.
        const int State_Dance = 0;
        const int State_Spell = 1;
        const int State_Teleport = 2;
        const int State_Still = 3;

        // This is a property (https://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx), it is very useful and helps keep out AI code clear of clutter.
        // Without it, every instance of "AI_State" in the AI code below would be "npc.ai[AI_State_Slot]". 
        // Also note that without the "AI_State_Slot" defined above, this would be "npc.ai[0]".
        // This is all to just make beautiful, manageable, and clean code.
        public float AI_State
        {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer
        {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float AI_SpellTime
        {
            get { return npc.ai[AI_Dance_Time_Slot]; }
            set { npc.ai[AI_Dance_Time_Slot] = value; }
        }

        // AdvancedFlutterSlime will need: float in water, diminishing aggo, spawn projectiles.

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            // The npc starts in the asleep state, waiting for a player to enter range
            if (AI_State == State_Dance)
            {
                float distance = 800f;
                float closest = 1000f, last = 800f;
                Player p;

                for (int k = 0; k < 200; k++)
                {
                    p = Main.player[k];
                    if (p.active)
                    {
                        if (npc.WithinRange(p.Center, distance))
                        {
                            if ((last = npc.Distance(p.Center)) < closest && last >= 150)
                            {
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

                // TargetClosest sets npc.target to the player.whoAmI of the closest player. the faceTarget parameter means that npc.direction will automatically be 1 or -1 if the targetted player is to the right or left. This is also automatically flipped if npc.confused
                npc.TargetClosest(true);
                // Now we check the make sure the target is still valid and within our specified notice range (500)
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 350f)
                {
                    // Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
                    AI_State = State_Spell;
                    AI_Timer = 0;
                }
            }
            // In this state, a player has been targeted
            else if (AI_State == State_Spell)
            {
                /// If the targeted player is in attack range (250).
                AI_Timer++;
                if (Main.player[npc.target].Distance(npc.Center) < 100f)
                {
                    if (AI_Timer >= 60)
                    {
                        AI_State = State_Teleport;
                    }
                }
                else
                {
                    npc.TargetClosest(true);
                    if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 350f)
                    {
                        // Out targetted player seems to have left our range, so we'll go back to sleep.
                        AI_State = State_Dance;
                        AI_Timer = 0;
                    }


                    if (AI_Timer >= 60)
                    {
                        Vector2 speed = Main.player[npc.target].Center - npc.Center;
                        AdjustMagnitude(ref speed);
                        AI_Timer = 0;
                        if (Main.netMode != 1)
                        {
                            Projectile.NewProjectile(npc.Center.X + 6, npc.Center.Y - 16, speed.X, speed.Y, mod.ProjectileType("SoulSpearProjHostile"), npc.damage, 0f);
                        }
                    }
                }
            }
            // In this state, we are in the jump. 
            else if (AI_State == State_Teleport)
            {
                Vector2 pos;
                if (npc.ai[3] == 1f) pos = new Vector2(npc.localAI[0], npc.localAI[1]);
                else if (npc.ai[3] == 0f && npc.Distance(new Vector2(npc.localAI[2], npc.localAI[3])) >= 150) pos = new Vector2(npc.localAI[2], npc.localAI[3]);
                else pos = new Vector2(npc.position.X + ((Main.rand.NextBool()) ? +200 : -200), npc.position.Y);
                npc.localAI[2] = npc.position.X;
                npc.localAI[3] = npc.position.Y;
                npc.Teleport(pos, 0, 0);
                npc.ai[3] = 0f;
                AI_State = State_Spell;
            }
            // In this state, our npc starts to flutter/fly a little to make it's movement a little bit interesting.
            else if (AI_State == State_Still)
            {
                AI_Timer += 1;
                // Here we make a decision on how long this flutter will last. We check netmode != 1 to prevent Multiplayer Clients from running this code. (similiarly, spawning projectiles should also be wrapped like this)
                // netmode == 0 is SP, netmode == 1 is MP Client, netmode == 2 is MP Server. 
                // Typically in MP, Client and Server maintain the same state by running deterministic code individually. When we want to do something random, we must do that on the server and then inform MP Clients.
                // Informing MP Clients is done automatically by syncing the npc.ai array over the network whenever npc.netUpdate is set. Don't set netUpdate unless you do something non-deterministic ("random")
                if (AI_Timer == 1)
                {
                    // For reference: without proper syncing: https://gfycat.com/BackAnxiousFerret and with proper syncing: https://gfycat.com/TatteredKindlyDalmatian
                    AI_SpellTime = 50;
                    npc.netUpdate = true;
                }
                // Here we add a tiny bit of upward velocity to our npc.


                if (AI_Timer > AI_SpellTime)
                {
                    // after fluttering for 100 ticks (1.66 seconds), our Flutter Slime is tired, so he decides to go into the Fall state.
                    AI_State = State_Dance;
                    AI_Timer = 0;
                }
            }
        }

        // Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
        const int Frame_Teleport = 0;
        const int Frame_Spell = 6;
        const int Frame_Dance_1 = 1;
        const int Frame_Dance_2 = 2;
        const int Frame_Dance_3 = 3;
        const int Frame_Dance_4 = 4;
        const int Frame_Dance_5 = 5;
        const int Frame_Dance_6 = 6;

        // Here in FindFrame, we want to set the animation frame our npc will use depending on what it is doing.
        // We set npc.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convinience, I have defined some consts above.
        public override void FindFrame(int frameHeight)
        {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.spriteDirection = npc.direction;

            // For the most part, our animation matches up with our states.
            if (AI_State == State_Teleport)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                npc.frame.Y = Frame_Teleport * frameHeight;
            }
            else if (AI_State == State_Spell)
            {
                AI_SpellTime++;
                // Going from Notice to Asleep makes our npc look like it's crouching to jump.
                if (AI_SpellTime < 10)
                {
                    npc.frame.Y = Frame_Teleport * frameHeight;
                }
                else
                {
                    npc.frame.Y = Frame_Spell * frameHeight;
                }
                if (AI_SpellTime >= 60)
                {
                    //Vector2 speed = Main.player[npc.target].Center - npc.Center;
                    //AdjustMagnitude(ref speed);
                    AI_SpellTime = 0;
                    //if (Main.netMode != 1)
                    //{
                    //    Projectile.NewProjectile(npc.Center.X + 6, npc.Center.Y - 16, speed.X, speed.Y, mod.ProjectileType("SoulSpearProjHostile"), 15, 0f);
                    //}
                }
            }
            else if (AI_State == State_Dance)
            {
                // Here we have 3 frames that we want to cycle through.

                npc.frameCounter++;
                if (npc.frameCounter < 8)
                {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                }
                else if (npc.frameCounter < 16)
                {
                    npc.frame.Y = Frame_Dance_2 * frameHeight;
                }
                else if (npc.frameCounter < 24)
                {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                }
                else if (npc.frameCounter < 32)
                {
                    npc.frame.Y = Frame_Dance_2 * frameHeight;
                }
                else if (npc.frameCounter < 40)
                {
                    npc.frame.Y = Frame_Dance_1 * frameHeight;
                }
                else if (npc.frameCounter < 48)
                {
                    npc.frame.Y = Frame_Dance_3 * frameHeight;
                }
                else if (npc.frameCounter < 56)
                {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                }
                else if (npc.frameCounter < 64)
                {
                    npc.frame.Y = Frame_Dance_5 * frameHeight;
                }
                else if (npc.frameCounter < 72)
                {
                    npc.velocity = new Vector2(0, -1);
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                }
                else if (npc.frameCounter < 80)
                {
                    npc.frame.Y = Frame_Dance_5 * frameHeight;
                }
                else if (npc.frameCounter < 88)
                {
                    npc.frame.Y = Frame_Dance_4 * frameHeight;
                }
                else if (npc.frameCounter < 96)
                {
                    npc.frame.Y = Frame_Dance_6 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }

            else if (AI_State == State_Still)
            {
                // Going from Notice to Asleep makes our npc look like it's crouching to jump.
                npc.frame.Y = Frame_Teleport * frameHeight;

            }

        }


        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 7.5f)
            {
                vector *= 7.5f / magnitude;
            }
        }
    }
}
