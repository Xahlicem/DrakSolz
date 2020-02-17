using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Hallow {

    public class HallowMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneHoly && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<MiniSun>(), 40f);
                pool.Add(ModContent.NPCType<DecoratedEnlistee>(), 40f);
                pool.Add(ModContent.NPCType<Solpiercer>(), 20f);
                pool.Add(ModContent.NPCType<SettingSun>(), 20f);
                pool.Add(ModContent.NPCType<Valekeeper>(), 20f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
            if (spawnInfo.player.ZoneHoly && spawnInfo.player.ZoneDirtLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<MiniSun>(), 40f);
                pool.Add(ModContent.NPCType<SettingSun>(), 30f);
                pool.Add(ModContent.NPCType<Solpiercer>(), 25f);
                pool.Add(ModContent.NPCType<SunWisp>(), 15f);
                pool.Add(ModContent.NPCType<Solarius>(), 15f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
            if (spawnInfo.player.ZoneHoly && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<SunWisp>(), 30f);
                pool.Add(ModContent.NPCType<SettingSun>(), 30f);
                pool.Add(ModContent.NPCType<Solarius>(), 30f);
                pool.Add(ModContent.NPCType<Oakenheart>(), 25f);
                pool.Add(ModContent.NPCType<Solpiercer>(), 20f);
                pool.Add(ModContent.NPCType<Peacekeeper>(), 20f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DivineSister>(), 1f);
            }
        }
    }
}