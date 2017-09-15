using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy
{
	// This ModNPC serves as an example of a complete AI example.
	public class Nito : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nito");
			Main.npcFrameCount[npc.type] = 4; // make sure to set this for your modnpcs.
		}

		public override void SetDefaults()
		{
			npc.width = 24;
            npc.scale *= 1.1f;
			npc.height = 44;
			npc.aiStyle = 3;
			aiType = NPCID.AngryBones;
			animationType = NPCID.Zombie;
			npc.damage = 60;
			npc.defense = 25;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			//npc.alpha = 175;
			//npc.color = new Color(0, 80, 255, 100);
			npc.value = 50000f;
            npc.knockBackResist = 1f;
			npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			// we would like this npc to spawn in the overworld.
			return SpawnCondition.Mummy.Chance * 0.5f;
		}
public override void FindFrame(int frameHeight)
		{
			// This makes the sprite flip horizontally in conjunction with the npc.direction.
			npc.spriteDirection = npc.direction;
		}
	}
}