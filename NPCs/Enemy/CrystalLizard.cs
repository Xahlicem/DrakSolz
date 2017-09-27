using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy
{
	// This ModNPC serves as an example of a complete AI example.
	public class CrystalLizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Lizard");
			Main.npcFrameCount[npc.type] = 11; // make sure to set this for your modnpcs.
		}

		public override void SetDefaults()
		{
			npc.width = 30;
            npc.scale *= 1;
			npc.height = 20;
			npc.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1.
			npc.damage = 20;
			npc.defense = 15;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			//npc.alpha = 175;
			//npc.color = new Color(0, 80, 255, 100);
			npc.value = 100000f;
            npc.knockBackResist = 0.1f;
			npc.buffImmune[BuffID.Confused] = true; // npc default to being immune to the Confused debuff. Allowing confused the AI. npc.confused is true while the npc is confused.
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.CrystalLizardBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			// we would like this npc to spawn in the overworld.
			return SpawnCondition.Cavern.Chance * 0.01f;
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
        const int State_Run = 2;


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


		// AdvancedFlutterSlime will need: float in water, diminishing aggo, spawn projectiles.

		// Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
		public override void AI()
		{
			// The npc starts in the asleep state, waiting for a player to enter range
			if (AI_State == State_Still)
			{
				// TargetClosest sets npc.target to the player.whoAmI of the closest player. the faceTarget parameter means that npc.direction will automatically be 1 or -1 if the targetted player is to the right or left. This is also automatically flipped if npc.confused
				npc.TargetClosest(true);

				// Now we check the make sure the target is still valid and within our specified notice range (500)
				if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 250f)
				{
					// Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
					AI_State = State_Walk;
					AI_Timer = 0;
				}
				else if(npc.life < npc.lifeMax)
				{
					AI_Timer++;
					if (AI_Timer >= 10)
					{
						AI_State = State_Walk;
						AI_Timer = 0;
					}
				}
			}
			// In this state, a player has been targeted
			else if (AI_State == State_Still)
			{
				/// If the targeted player is in attack range (250).
				if (npc.life < npc.lifeMax)
				{
					// Here we use our Timer to wait .33 seconds before actually jumping. In FindFrame you'll notice AI_Timer also being used to animate the pre-jump crouch
					AI_Timer++;
					if (AI_Timer >= 10)
					{
						AI_State = State_Walk;
						AI_Timer = 0;
					}
				}
			}
			// In this state, we are in the jump. 
			else if (AI_State == State_Run)
			{
				AI_Timer++;
				if (AI_Timer < 12)
				{
					npc.alpha = 0;
				}

				else if (AI_Timer < 24)
				{
					npc.alpha = 20;
				}
				else if (AI_Timer < 36)
				{
					npc.alpha = 40;
				}
				else if (AI_Timer < 48)
				{
					npc.alpha = 55;
				}
				else if (AI_Timer < 60)
				{
					npc.alpha = 70;
				}
				else if (AI_Timer < 72)
				{
					npc.alpha = 85;
				}
				else if (AI_Timer < 84)
				{
					npc.alpha = 100;
				}
				else if (AI_Timer < 96)
				{
					npc.alpha = 120;
				}
				else if (AI_Timer < 108)
				{
					npc.alpha = 140;
				}
				else if (AI_Timer < 120)
				{
					npc.alpha = 160;
				}
				else if (AI_Timer < 132)
				{
					npc.alpha = 180;
				}
				else if (AI_Timer < 144)
				{
					npc.alpha = 200;
				}
				else
				{
					// after .66 seconds, we go to the hover state. // TODO, gravity?
					npc.alpha = 255;
					npc.life = 0;
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
        const int Frame_Walk_8 = 0;
        const int Frame_Run_1 = 8;
        const int Frame_Run_2 = 9;
        const int Frame_Run_3 = 10;
        const int Frame_Run_4 = 9;


		// Here in FindFrame, we want to set the animation frame our npc will use depending on what it is doing.
		// We set npc.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convinience, I have defined some consts above.
		public override void FindFrame(int frameHeight)
		{
			// This makes the sprite flip horizontally in conjunction with the npc.direction.
			npc.spriteDirection = npc.direction;

			// For the most part, our animation matches up with our states.
			if (AI_State == State_Still)
			{
				// npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
				npc.frame.Y = Frame_Still * frameHeight;
				npc.velocity = new Vector2(npc.direction * 0, 0);
			}
			else if (AI_State == State_Run)
			{
				// Going from Notice to Asleep makes our npc look like it's crouching to jump.
				npc.frameCounter++;
				if (npc.frameCounter < 6)
				{
					npc.frame.Y = Frame_Run_1 * frameHeight;
				}
				else if (npc.frameCounter < 12)
				{
					npc.frame.Y = Frame_Run_2 * frameHeight;
				}
				else if (npc.frameCounter < 18)
				{
					npc.frame.Y = Frame_Run_3 * frameHeight;
				}
				else if (npc.frameCounter < 24)
				{
					npc.frame.Y = Frame_Run_2 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
			else if (AI_State == State_Walk)
			{
				// Here we have 3 frames that we want to cycle through.
				npc.frameCounter++;
				if (npc.frameCounter < 4)
				{
					npc.frame.Y = Frame_Walk_1 * frameHeight;
					if (Math.Abs(npc.velocity.X) < 1)
				{
					npc.velocity = new Vector2(npc.direction * -5, 0);
				}
				}
				else if (npc.frameCounter < 8)
				{
					npc.frame.Y = Frame_Walk_2 * frameHeight;
				}
				else if (npc.frameCounter < 12)
				{
					npc.frame.Y = Frame_Walk_3 * frameHeight;
					if (Math.Abs(npc.velocity.X) < 1)
				{
					AI_State = State_Run;
				}
				}
                else if (npc.frameCounter < 16)
				{
					npc.frame.Y = Frame_Walk_4 * frameHeight;
				}
				else if (npc.frameCounter < 20)
				{
					npc.frame.Y = Frame_Walk_5 * frameHeight;
				}
                else if (npc.frameCounter < 24)
				{
					npc.frame.Y = Frame_Walk_6 * frameHeight;
				}
				else if (npc.frameCounter < 28)
				{
					npc.frame.Y = Frame_Walk_7 * frameHeight;
				}
                else if (npc.frameCounter < 32)
				{
					npc.frame.Y = Frame_Walk_8 * frameHeight;
				}
				else
				{
					npc.frameCounter = 0;
				}
			}
		}
	}
}