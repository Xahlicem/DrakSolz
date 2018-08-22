using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {

    public class JungleMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneJungle && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.VerdantSister>(), 1f);
            }
        }
    }
}