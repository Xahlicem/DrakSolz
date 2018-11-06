using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Underworld {

    public class UnderworldMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneUnderworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<Flamewreath>(), 40f);
                pool.Add(mod.NPCType<InfernalLocust>(), 35f);
                pool.Add(mod.NPCType<Phantasm>(), 35f);
                pool.Add(mod.NPCType<Cacophynos>(), 20f);
                pool.Add(mod.NPCType<DeathKnell>(), 20f);
                pool.Add(mod.NPCType<FireElemental>(), 20f);
                pool.Add(mod.NPCType<Marauder>(), 20f);
                pool.Add(mod.NPCType<Nightshroud>(), 20f);
                pool.Add(mod.NPCType<Furiosa>(), 15f);
                pool.Add(mod.NPCType<InfernalBookMaster>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.InfernalSister>(), 1f);
            }
        }
    }
}