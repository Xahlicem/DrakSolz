using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Underworld {

    public class UnderworldMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneUnderworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<Flamewreath>(), 40f);
                pool.Add(ModContent.NPCType<InfernalLocust>(), 35f);
                pool.Add(ModContent.NPCType<Phantasm>(), 35f);
                pool.Add(ModContent.NPCType<Cacophynos>(), 20f);
                pool.Add(ModContent.NPCType<DeathKnell>(), 20f);
                pool.Add(ModContent.NPCType<FireElemental>(), 20f);
                pool.Add(ModContent.NPCType<Marauder>(), 20f);
                pool.Add(ModContent.NPCType<Nightshroud>(), 20f);
                pool.Add(ModContent.NPCType<Furiosa>(), 15f);
                pool.Add(ModContent.NPCType<InfernalBookMaster>(), 15f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.InfernalSister>(), 1f);
            }
        }
    }
}