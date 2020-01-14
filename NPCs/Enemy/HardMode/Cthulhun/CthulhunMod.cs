using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode.Cthulhun {

    public class CthulhunMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneBeach && spawnInfo.player.ZoneOverworldHeight && NPC.downedMechBossAny) {
                pool.Add(mod.NPCType<Cthulhun>(), 10f);
                pool.Add(mod.NPCType<CthulhunRoyalty>(), 4f);
                pool.Add(mod.NPCType<CthulhunKing>(), 1f);

            }
        }
    }
}