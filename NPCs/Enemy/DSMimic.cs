using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class DSMimic : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mimic");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.width = 24;
            npc.scale *= 1.1f;
            npc.height = 44;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            npc.damage = 60;
            npc.defense = 25;
            npc.lifeMax = 750;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 50000f;
            npc.knockBackResist = 1f;
            npc.buffImmune[BuffID.Confused] = false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            //return SpawnCondition.Mummy.Chance * 0.5f;
            return 0;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
    }
}