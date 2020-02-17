using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Dungeon {

    public class DungeonMod2 : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneDungeon && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<SwordofAkrane>(), 40f);
                pool.Add(ModContent.NPCType<WhiteWidow>(), 35f);
                pool.Add(ModContent.NPCType<Rejuvenator>(), 30f);
                pool.Add(ModContent.NPCType<Bladeseeker>(), 30f);
                pool.Add(ModContent.NPCType<Heretic>(), 20f);
                pool.Add(ModContent.NPCType<HighTemplar>(), 15f);
                pool.Add(ModContent.NPCType<Shinkage>(), 10f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.VigilantSister>(), 1f);
            }
        }
    }
}