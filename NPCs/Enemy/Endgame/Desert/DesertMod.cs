using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {

    public class DesertMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneDesert && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<Scarabyte>(), 40f);
                pool.Add(mod.NPCType<MirageMonster>(), 30f);
                pool.Add(mod.NPCType<OrbWeaver>(), 30f);
                pool.Add(mod.NPCType<AridMechanyst>(), 25f);
                pool.Add(mod.NPCType<Orbrider>(), 20f);
                pool.Add(mod.NPCType<AymaraHealer>(), 10f);
                pool.Add(mod.NPCType<Obelysk>(), 10f);
                pool.Add(mod.NPCType<WindShrike>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.AridSister>(), 1f);
            }
            if (spawnInfo.player.ZoneUndergroundDesert && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<Scarabyte>(), 30f);
                pool.Add(mod.NPCType<WindShrike>(), 30f);
                pool.Add(mod.NPCType<SandHowler>(), 30f);
                pool.Add(mod.NPCType<AridBlade>(), 20f);
                pool.Add(mod.NPCType<Obelysk>(), 20f);
                pool.Add(mod.NPCType<AymaraHealer>(), 10f);
                pool.Add(mod.NPCType<AridCaster>(), 10f);
                pool.Add(mod.NPCType<Starless>(), 10f);
                pool.Add(mod.NPCType<Paradigm>(), 10f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.AridSister>(), 1f);
            }
        }
    }
}