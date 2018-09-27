using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {
    public class LittleMushroom : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Little Mushroom");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Zombie);
            npc.scale = 1;
            npc.width = 24;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.Mummy;
            animationType = NPCID.Zombie;
            npc.damage = 8;
            npc.defense = 4;
            npc.lifeMax = 30;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.8f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.LittleMushroomBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.OverworldDay.Chance * 0.2f;
        }
        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/LittleMushroom/Gore_0");
            DrakSolz.CreateGore(mod, npc, "Gores/LittleMushroom/Gore_1");
            DrakSolz.DropItem(npc, 100f, ItemID.Mushroom, Main.rand.Next(1, 2));
        }
    }
}