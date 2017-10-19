using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
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
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LittleMushroom_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LittleMushroom_Gore_2"));
            Main.gore[g].scale = npc.scale;
            Item.NewItem(npc.Center, npc.width, npc.height, ItemID.Mushroom, Main.rand.Next(1, 2));
        }
    }
}