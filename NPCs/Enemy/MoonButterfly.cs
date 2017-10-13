using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class MoonButterfly : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Butterfly");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Moth);
            npc.scale = 1.5f;
            npc.width = 24;
            //npc.aiStyle = 39;
            aiType = NPCID.Moth;
            animationType = NPCID.Moth;
            npc.height = 70;
            npc.damage = 80;
            npc.defense = 40;
            npc.lifeMax = 3500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 8000f;
            npc.knockBackResist = 0f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.MoonButterflyBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
                return SpawnCondition.OverworldDay.Chance * 0.2f;
        }
        public override void NPCLoot() {
            /*int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LittleMushroom_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LittleMushroom_Gore_2"));
            Main.gore[g].scale = npc.scale;
            Item.NewItem(npc.Center, npc.width, npc.height, ItemID.Mushroom, Main.rand.Next(1, 2));*/
        }
    }
}