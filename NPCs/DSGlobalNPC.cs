using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.NPCs {
    class DSGlobalNPC : GlobalNPC {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
            float mul = 1f;
            if (NPC.downedSlimeKing) mul *= 1.1f;
            if (NPC.downedQueenBee) mul *= 1.1f;
            if (NPC.downedBoss1) mul *= 1.1f;
            if (NPC.downedBoss2) mul *= 1.1f;
            if (NPC.downedBoss3) mul *= 1.1f;
            if (Main.hardMode) mul *= 1.1f;
            if (NPC.downedMechBoss1) mul *= 1.1f;
            if (NPC.downedMechBoss2) mul *= 1.1f;
            if (NPC.downedMechBoss3) mul *= 1.1f;
            if (NPC.downedPlantBoss) mul *= 1.1f;
            if (NPC.downedGolemBoss) mul *= 1.1f;
            if (NPC.downedAncientCultist) mul *= 0.6f;
            if (NPC.downedFishron) mul *= 1.1f;
            if (NPC.downedMoonlord) mul *= 1.4f;
            spawnRate = (int)(spawnRate / mul);
            maxSpawns = (int)(maxSpawns * mul);
        }
    }
}