using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {

    public class CorruptMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneOverworldHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<DeepfireDevourer>(), 50f);
                pool.Add(mod.NPCType<CarrionCollector>(), 40f);
                pool.Add(mod.NPCType<Hexclaw>(), 35f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<Gibbet>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneDirtLayerHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(mod.NPCType<Hexclaw>(), 40f);
                pool.Add(mod.NPCType<VorpalReaver>(), 30f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<Gibbet>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneRockLayerHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<Desolator>(), 50f);
                pool.Add(mod.NPCType<VorpalReaver>(), 45f);
                pool.Add(mod.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(mod.NPCType<BlackSolus>(), 30f);
                pool.Add(mod.NPCType<Gibbet>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneOverworldHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<DeepfireDevourer>(), 50f);
                pool.Add(mod.NPCType<CarrionCollector>(), 40f);
                pool.Add(mod.NPCType<Hexclaw>(), 35f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<Gibbet>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneDirtLayerHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(mod.NPCType<Hexclaw>(), 40f);
                pool.Add(mod.NPCType<VorpalReaver>(), 30f);
                pool.Add(mod.NPCType<SoulWraith>(), 25f);
                pool.Add(mod.NPCType<Gibbet>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneRockLayerHeight && NPC.downedMoonlord) {
                pool.Clear();
                pool.Add(mod.NPCType<Desolator>(), 50f);
                pool.Add(mod.NPCType<VorpalReaver>(), 45f);
                pool.Add(mod.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(mod.NPCType<BlackSolus>(), 30f);
                pool.Add(mod.NPCType<Gibbet>(), 5f);
                pool.Add(mod.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
        }
    }
}