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
                    pool.Add(ModContent.NPCType<Shadowdancer>(), 35f);
                    pool.Add(ModContent.NPCType<Ghoulie>(), 25f);
                    pool.Add(ModContent.NPCType<VoidTalon>(), 20f);
                    pool.Add(ModContent.NPCType<NightWatcher>(), 15f);
                }
                if (spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon] && Main.bloodMoon && !Main.dayTime && Main.time < 32400.0) {
                    pool.Clear();
                    pool.Add(ModContent.NPCType<Nightsorrow>(), 35f);
                    pool.Add(ModContent.NPCType<Silhouette>(), 25f);
                    pool.Add(ModContent.NPCType<NightmareOperant>(), 25f);
                    pool.Add(ModContent.NPCType<ReaperNineMoons>(), 15f);
                    pool.Add(ModContent.NPCType<BloodmoonAssassin>(), 10f);
                }
                if (spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon] && Main.dayTime) {
                    pool.Clear();
                    pool.Add(ModContent.NPCType<Dragonlark>(), 30f);
                    pool.Add(ModContent.NPCType<NPCs.Enemy.Dungeon.SilverKnightArcher>(), 20f);
                    pool.Add(ModContent.NPCType<NPCs.Enemy.Dungeon.SilverKnight>(), 15f);
                    pool.Add(ModContent.NPCType<NPCs.Enemy.Dungeon.SilverKnightSpear>(), 15f);
                    pool.Add(ModContent.NPCType<DustWailer>(), 10f);
                    pool.Add(NPCID.Salamander, 35f);
                }
            }
        }
    }
}