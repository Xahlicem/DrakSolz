using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    // This ModNPC serves as an example of a complete AI example.
    public class WheelSkeleton : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wheel Skeleton");
            Main.npcFrameCount[npc.type] = 1; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults() {
            npc.width = 30;
            npc.scale *= 1.0f;
            npc.height = 30;
            npc.aiStyle = 26;
            aiType = NPCID.Tumbleweed;
            animationType = NPCID.Tumbleweed;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 110;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100;
            npc.knockBackResist = 1f;
            //npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedBoss3){
            return SpawnCondition.OverworldNightMonster.Chance * 0.3f;}
            else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot() {
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.BoneWheel>());
        }

    }
}