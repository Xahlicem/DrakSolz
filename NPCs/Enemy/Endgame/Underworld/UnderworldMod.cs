using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Underworld {

    public class UnderworldMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneUnderworldHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.InfernalSister>(), 1f);
            }
        }
    }
}