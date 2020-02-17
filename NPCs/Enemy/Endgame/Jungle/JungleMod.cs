using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {

    public class JungleMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneJungle && NPC.downedMoonlord) {
                pool.Clear();
                if (spawnInfo.player.ZoneJungle && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Add(ModContent.NPCType<EarthWalker>(), 35f);
                pool.Add(ModContent.NPCType<Slither>(), 40f);
                pool.Add(ModContent.NPCType<Rex>(), 30f);
                pool.Add(ModContent.NPCType<Harvester>(), 12f);
                pool.Add(ModContent.NPCType<Ripper>(), 15f);
                pool.Add(ModContent.NPCType<CrystalMonarch>(), 15f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.VerdantSister>(), 1f);
                }
                if (spawnInfo.player.ZoneJungle && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Add(ModContent.NPCType<BeastcladHunter>(), 15f);
                pool.Add(ModContent.NPCType<CrystalMonarch>(), 15f);
                pool.Add(ModContent.NPCType<Dendritic>(), 10f);
                pool.Add(ModContent.NPCType<Harvester>(), 16f);
                pool.Add(ModContent.NPCType<Juggernaut>(), 8f);
                pool.Add(ModContent.NPCType<PrimordialGazer>(), 20f);
                pool.Add(ModContent.NPCType<Ripper>(), 20f);
                pool.Add(ModContent.NPCType<SylvanCaster>(), 15f);
                pool.Add(ModContent.NPCType<SylvanRampager>(), 12f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.VerdantSister>(), 1f);
                }
                if (spawnInfo.player.ZoneJungle && (spawnInfo.spawnTileY <= Main.maxTilesY - 200 && spawnInfo.spawnTileY > Main.maxTilesY - 400) && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Add(ModContent.NPCType<Progenitor>(), 20f);
                pool.Add(ModContent.NPCType<Ragebinder>(), 18f);
                pool.Add(ModContent.NPCType<Vindicator>(), 16f);
                }
            }
        }
    }
}