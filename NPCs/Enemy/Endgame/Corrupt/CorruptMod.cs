using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {

    public class CorruptMod : GlobalNPC {

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<DeepfireDevourer>(), 50f);
                pool.Add(ModContent.NPCType<CarrionCollector>(), 40f);
                pool.Add(ModContent.NPCType<Hexclaw>(), 35f);
                pool.Add(ModContent.NPCType<SoulWraith>(), 25f);
                pool.Add(ModContent.NPCType<Gibbet>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneDirtLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(ModContent.NPCType<Hexclaw>(), 40f);
                pool.Add(ModContent.NPCType<VorpalReaver>(), 30f);
                pool.Add(ModContent.NPCType<SoulWraith>(), 25f);
                pool.Add(ModContent.NPCType<Gibbet>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<Desolator>(), 50f);
                pool.Add(ModContent.NPCType<VorpalReaver>(), 45f);
                pool.Add(ModContent.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(ModContent.NPCType<BlackSolus>(), 30f);
                pool.Add(ModContent.NPCType<Gibbet>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneOverworldHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<DeepfireDevourer>(), 50f);
                pool.Add(ModContent.NPCType<CarrionCollector>(), 40f);
                pool.Add(ModContent.NPCType<Hexclaw>(), 35f);
                pool.Add(ModContent.NPCType<SoulWraith>(), 25f);
                pool.Add(ModContent.NPCType<Gibbet>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneDirtLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(ModContent.NPCType<Hexclaw>(), 40f);
                pool.Add(ModContent.NPCType<VorpalReaver>(), 30f);
                pool.Add(ModContent.NPCType<SoulWraith>(), 25f);
                pool.Add(ModContent.NPCType<Gibbet>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
            if (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneRockLayerHeight && DrakSolzWorld.downedBoss[DrakSolzWorld.Boss.TitaniteDemon]) {
                pool.Clear();
                pool.Add(ModContent.NPCType<Desolator>(), 50f);
                pool.Add(ModContent.NPCType<VorpalReaver>(), 45f);
                pool.Add(ModContent.NPCType<DeepfireDevourer>(), 40f);
                pool.Add(ModContent.NPCType<BlackSolus>(), 30f);
                pool.Add(ModContent.NPCType<Gibbet>(), 5f);
                pool.Add(ModContent.NPCType<NPCs.Enemy.Endgame.Secret.DemonicSister>(), 1f);
            }
        }
    }
}