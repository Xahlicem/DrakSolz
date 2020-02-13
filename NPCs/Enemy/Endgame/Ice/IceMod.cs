using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Ice {

    public class IceMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
             if (spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<Shivers>(), 40f);
                pool.Add(ModContent.NPCType<DiscipleYggdra>(), 30f);
                pool.Add(ModContent.NPCType<HearthSister>(), 30f);
                pool.Add(ModContent.NPCType<AncientGrove>(), 20f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.FrigidSister>(), 1f);
            }
            if (spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneDirtLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<CrystalWisp>(), 40f);
                pool.Add(ModContent.NPCType<Cryoblade>(), 20f);
                pool.Add(ModContent.NPCType<CrystalArbiter>(), 20f);
                pool.Add(ModContent.NPCType<HearthSister>(), 20f);
                //pool.Add(ModContent.NPCType<Myriad>(), 20f);
                pool.Add(ModContent.NPCType<Protosensor>(), 20f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.FrigidSister>(), 1f);
            }
            if (spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<CrystalWisp>(), 40f);
                pool.Add(ModContent.NPCType<Nemeton>(), 30f);
                pool.Add(ModContent.NPCType<Grandmaster>(), 20f);
                pool.Add(ModContent.NPCType<Voracity>(), 10f);
                pool.Add(ModContent.NPCType<Xel>(), 10f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.FrigidSister>(), 1f);
            }
        }
    }
}