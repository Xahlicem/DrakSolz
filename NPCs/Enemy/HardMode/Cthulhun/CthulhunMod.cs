using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode.Cthulhun {

    public class CthulhunMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneBeach && spawnInfo.player.ZoneOverworldHeight && NPC.downedMechBossAny) {
                pool.Add(ModContent.NPCType<Cthulhun>(), 0.65f);
                pool.Add(ModContent.NPCType<CthulhunRoyalty>(), 0.3f);
                pool.Add(ModContent.NPCType<CthulhunKing>(), 0.1f);

            }
            else if (spawnInfo.player.ZoneBeach && spawnInfo.player.ZoneOverworldHeight && Main.hardMode) {
                pool.Add(ModContent.NPCType<Cthulhun>(), 0.3f);
                pool.Add(ModContent.NPCType<CthulhunRoyalty>(), 0.1f);

            }
        }
    }
}