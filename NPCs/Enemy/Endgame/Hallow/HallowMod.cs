using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Hallow {

    public class HallowMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneHoly && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
        }
    }
}