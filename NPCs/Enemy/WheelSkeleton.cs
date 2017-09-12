using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.NPCs.Enemy {
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
            npc.damage = 60;
            npc.defense = 25;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 500;
            npc.knockBackResist = 1f;
            //npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.Wraith.Chance * 0.5f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
    }
}