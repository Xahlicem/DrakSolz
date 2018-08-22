using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {

    public class CorruptMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneCorrupt && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
        }
    }
}