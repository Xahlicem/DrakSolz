using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Hallow {

    public class HallowMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneHoly && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<MiniSun>(), 40f);
                pool.Add(mod.NPCType<DecoratedEnlistee>(), 40f);
                pool.Add(mod.NPCType<Solpiercer>(), 20f);
                pool.Add(mod.NPCType<SettingSun>(), 20f);
                pool.Add(mod.NPCType<Valekeeper>(), 20f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
            if (spawnInfo.player.ZoneHoly && spawnInfo.player.ZoneDirtLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<MiniSun>(), 40f);
                pool.Add(mod.NPCType<SettingSun>(), 30f);
                pool.Add(mod.NPCType<Solpiercer>(), 25f);
                pool.Add(mod.NPCType<SunWisp>(), 15f);
                pool.Add(mod.NPCType<Solarius>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
            if (spawnInfo.player.ZoneHoly && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<SunWisp>(), 30f);
                pool.Add(mod.NPCType<SettingSun>(), 30f);
                pool.Add(mod.NPCType<Solarius>(), 30f);
                pool.Add(mod.NPCType<Oakenheart>(), 25f);
                pool.Add(mod.NPCType<Solpiercer>(), 20f);
                pool.Add(mod.NPCType<Peacekeeper>(), 20f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
        }
    }
}