using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Dungeon {

    public class DungeonMod2 : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneDungeon && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<SwordofAkrane>(), 40f);
                pool.Add(mod.NPCType<WhiteWidow>(), 35f);
                pool.Add(mod.NPCType<Rejuvenator>(), 30f);
                pool.Add(mod.NPCType<Bladeseeker>(), 30f);
                pool.Add(mod.NPCType<Heretic>(), 20f);
                pool.Add(mod.NPCType<HighTemplar>(), 15f);
                pool.Add(mod.NPCType<Shinkage>(), 10f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.VigilantSister>(), 1f);
            }
        }
    }
}