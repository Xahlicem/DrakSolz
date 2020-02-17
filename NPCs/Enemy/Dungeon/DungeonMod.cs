using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Dungeon {

    public class DungeonMod : GlobalNPC {
        public override void SpawnNPC(int npc, int tileX, int tileY) {
            if (Main.npc[npc].type != ModContent.NPCType<PreHardMode.Channeler>()) return;
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
                pool.Add(ModContent.NPCType<Inhumanity>(), 6f);
                //pool.Add(NPCID.CultistArcherBlue, 4f);
                pool.Add(ModContent.NPCType<PreHardMode.Channeler>(), 1f);
                pool.Add(ModContent.NPCType<BlackKnight>(), 1f);
                pool.Add(ModContent.NPCType<SilverKnight>(), 4f);
                pool.Add(ModContent.NPCType<SilverKnightArcher>(), 2f);
                pool.Add(ModContent.NPCType<SilverKnightSpear>(), 4f);
            }
        }
    }
}