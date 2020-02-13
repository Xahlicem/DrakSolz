using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {

    public class DesertMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneDesert && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<Scarabyte>(), 40f);
                pool.Add(ModContent.NPCType<MirageMonster>(), 30f);
                pool.Add(ModContent.NPCType<OrbWeaver>(), 30f);
                pool.Add(ModContent.NPCType<AridMechanyst>(), 25f);
                pool.Add(ModContent.NPCType<Orbrider>(), 20f);
                pool.Add(ModContent.NPCType<AymaraHealer>(), 10f);
                pool.Add(ModContent.NPCType<Obelysk>(), 10f);
                pool.Add(ModContent.NPCType<WindShrike>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.AridSister>(), 1f);
            }
            if (spawnInfo.player.ZoneUndergroundDesert && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<Scarabyte>(), 30f);
                pool.Add(ModContent.NPCType<WindShrike>(), 30f);
                pool.Add(ModContent.NPCType<SandHowler>(), 30f);
                pool.Add(ModContent.NPCType<AridBlade>(), 20f);
                pool.Add(ModContent.NPCType<Obelysk>(), 20f);
                pool.Add(ModContent.NPCType<AymaraHealer>(), 10f);
                pool.Add(ModContent.NPCType<AridCaster>(), 10f);
                pool.Add(ModContent.NPCType<Starless>(), 10f);
                pool.Add(ModContent.NPCType<Paradigm>(), 10f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.AridSister>(), 1f);
            }
        }
    }
}