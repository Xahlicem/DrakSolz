using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {

    public class JungleMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneJungle && NPC.downedMoonlord) {
                pool.Clear();
                if (spawnInfo.player.ZoneJungle && spawnInfo.player.ZoneOverworldHeight && NPC.downedMoonlord) {
                pool.Add(mod.NPCType<EarthWalker>(), 35f);
                pool.Add(mod.NPCType<Slither>(), 40f);
                pool.Add(mod.NPCType<Rex>(), 30f);
                pool.Add(mod.NPCType<Harvester>(), 12f);
                pool.Add(mod.NPCType<Ripper>(), 15f);
                pool.Add(mod.NPCType<CrystalMonarch>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.VerdantSister>(), 1f);
                }
                if (spawnInfo.player.ZoneJungle && spawnInfo.player.ZoneRockLayerHeight && NPC.downedMoonlord) {
                pool.Add(mod.NPCType<BeastcladHunter>(), 15f);
                pool.Add(mod.NPCType<CrystalMonarch>(), 15f);
                pool.Add(mod.NPCType<Dendritic>(), 10f);
                pool.Add(mod.NPCType<Harvester>(), 16f);
                pool.Add(mod.NPCType<Juggernaut>(), 8f);
                pool.Add(mod.NPCType<PrimordialGazer>(), 20f);
                pool.Add(mod.NPCType<Ripper>(), 20f);
                pool.Add(mod.NPCType<SylvanCaster>(), 15f);
                pool.Add(mod.NPCType<SylvanRampager>(), 12f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.VerdantSister>(), 1f);
                }
                if (spawnInfo.player.ZoneJungle && (spawnInfo.spawnTileY <= Main.maxTilesY - 200 && spawnInfo.spawnTileY > Main.maxTilesY - 400) && NPC.downedMoonlord) {
                pool.Add(mod.NPCType<Progenitor>(), 20f);
                pool.Add(mod.NPCType<Ragebinder>(), 18f);
                pool.Add(mod.NPCType<Vindicator>(), 16f);
                }
            }
        }
    }
}