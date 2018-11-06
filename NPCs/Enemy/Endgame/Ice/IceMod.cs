using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Ice {

    public class IceMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
             if (spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<Shivers>(), 40f);
                pool.Add(mod.NPCType<DiscipleYggdra>(), 30f);
                pool.Add(mod.NPCType<HearthSister>(), 30f);
                pool.Add(mod.NPCType<AncientGrove>(), 20f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.FrigidSister>(), 1f);
            }
            if (spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneDirtLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<CrystalWisp>(), 40f);
                pool.Add(mod.NPCType<Cryoblade>(), 20f);
                pool.Add(mod.NPCType<CrystalArbiter>(), 20f);
                pool.Add(mod.NPCType<HearthSister>(), 20f);
                //pool.Add(mod.NPCType<Myriad>(), 20f);
                pool.Add(mod.NPCType<Protosensor>(), 20f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.FrigidSister>(), 1f);
            }
            if (spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(mod.NPCType<CrystalWisp>(), 40f);
                pool.Add(mod.NPCType<Nemeton>(), 30f);
                pool.Add(mod.NPCType<Grandmaster>(), 20f);
                pool.Add(mod.NPCType<Voracity>(), 10f);
                pool.Add(mod.NPCType<Xel>(), 10f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.FrigidSister>(), 1f);
            }
        }
    }
}