using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {

    public class DesertMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneUndergroundDesert && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.AridSister>(), 1f);
            }
            if (spawnInfo.player.ZoneDesert && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.AridSister>(), 1f);
            }
        }
    }
}