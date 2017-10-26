using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Dungeon {

    public class DungeonMod : GlobalNPC {
        public override void SpawnNPC(int npc, int tileX, int tileY) {
            if (Main.npc[npc].type != mod.NPCType<PreHardMode.Channeler>()) return;
            if (Main.hardMode) {
                Main.npc[npc].lifeMax *= 5;
                Main.npc[npc].life *= 5;
                Main.npc[npc].defDamage *= 3;
                Main.npc[npc].damage *= 3;
            }
            if (NPC.downedAncientCultist) {
                Main.npc[npc].lifeMax *= 5;
                Main.npc[npc].life *= 5;
                Main.npc[npc].defDefense *= 3;
                Main.npc[npc].defense *= 3;
            }
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.ZoneDungeon && NPC.downedAncientCultist) {
                pool.Clear();
                pool.Add(mod.NPCType<Inhumanity>(), 6f);
                //pool.Add(NPCID.CultistArcherBlue, 4f);
                pool.Add(mod.NPCType<PreHardMode.Channeler>(), 1f);
                pool.Add(mod.NPCType<VoidPillar.NPCs.BlackKnight>(), 1f);
                pool.Add(mod.NPCType<VoidPillar.NPCs.SilverKnight>(), 4f);
                pool.Add(mod.NPCType<VoidPillar.NPCs.SilverKnightArcher>(), 2f);
                pool.Add(mod.NPCType<VoidPillar.NPCs.SilverKnightSpear>(), 4f);
            }
        }
    }
}