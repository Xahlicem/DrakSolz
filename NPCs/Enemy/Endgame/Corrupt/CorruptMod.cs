using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {

    public class CorruptMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneOverworldHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<CarrionCollector>(), 40f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<VorpalReaver>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneRockLayerHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<CarrionCollector>(), 40f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<VorpalReaver>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneOverworldHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<CarrionCollector>(), 40f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<VorpalReaver>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneRockLayerHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<CarrionCollector>(), 40f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<VorpalReaver>(), 15f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
        }
    }
}