using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.OverWorld {

    public class OverWorld : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (!spawnInfo.player.ZoneHoly && !spawnInfo.player.ZoneCorrupt && !spawnInfo.player.ZoneCrimson && !spawnInfo.player.ZoneDesert && !spawnInfo.player.ZoneSnow && !spawnInfo.player.ZoneJungle) {
                if (spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon] && !Main.bloodMoon && !Main.dayTime && Main.time < 32400.0) {
                    pool.Clear();
                    pool.Add(mod.NPCType<Shadowdancer>(), 35f);
                    pool.Add(mod.NPCType<Ghoulie>(), 25f);
                    pool.Add(mod.NPCType<VoidTalon>(), 20f);
                    pool.Add(mod.NPCType<NightWatcher>(), 15f);
                }
                if (spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon] && Main.bloodMoon && !Main.dayTime && Main.time < 32400.0) {
                    pool.Clear();
                    pool.Add(mod.NPCType<Nightsorrow>(), 35f);
                    pool.Add(mod.NPCType<Silhouette>(), 25f);
                    pool.Add(mod.NPCType<NightmareOperant>(), 25f);
                    pool.Add(mod.NPCType<ReaperNineMoons>(), 15f);
                    pool.Add(mod.NPCType<BloodmoonAssassin>(), 10f);
                }
                if (spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon] && Main.dayTime) {
                    pool.Clear();
                    pool.Add(mod.NPCType<Dragonlark>(), 30f);
                    pool.Add(mod.NPCType<NPCs.Enemy.Dungeon.SilverKnightArcher>(), 20f);
                    pool.Add(mod.NPCType<NPCs.Enemy.Dungeon.SilverKnight>(), 15f);
                    pool.Add(mod.NPCType<NPCs.Enemy.Dungeon.SilverKnightSpear>(), 15f);
                    pool.Add(mod.NPCType<DustWailer>(), 10f);
                    pool.Add(NPCID.Salamander, 35f);
                }
            }
        }
    }
}