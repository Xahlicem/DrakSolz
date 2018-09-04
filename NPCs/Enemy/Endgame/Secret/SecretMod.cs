using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Secret {

    public class SecretMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneOverworldHeight) {
                pool.Add(mod.NPCType<NPCs.Enemy.PreHardMode.CrystalLizard>(), 0.001f);
            }
            if (spawnInfo.player.ZoneSkyHeight) {
                pool.Add(mod.NPCType<NPCs.Enemy.PreHardMode.CrystalLizard>(), 0.002f);
            }
            if (spawnInfo.player.ZoneDirtLayerHeight) {
                pool.Add(mod.NPCType<NPCs.Enemy.PreHardMode.CrystalLizard>(), 0.002f);
            }
            if (spawnInfo.player.ZoneRockLayerHeight) {
                pool.Add(mod.NPCType<NPCs.Enemy.PreHardMode.CrystalLizard>(), 0.004f);
            }
            if (spawnInfo.player.ZoneUnderworldHeight) {
                pool.Add(mod.NPCType<NPCs.Enemy.PreHardMode.CrystalLizard>(), 0.003f);
            }
        }
    }
}