using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class DragonSlayer : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dragonslayer");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSpearman);
            npc.scale = 1;
            npc.width = 24;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.SolarSolenian;
            animationType = NPCID.SolarSpearman;
            npc.damage = 70;
            npc.defense = 30;
            npc.lifeMax = 2500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 7500f;
            npc.knockBackResist = 0.01f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.DragonSlayerBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny && Main.raining)
                return SpawnCondition.OverworldHallow.Chance * 0.08f;
            else return 0f;
        }
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonSlayer_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonSlayer_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonSlayer_Gore_3"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonSlayer_Gore_4"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonSlayer_Gore_5"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DragonSlayer_Gore_6"));
            Main.gore[g].scale = npc.scale;
            if (Main.rand.Next(5) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.DragonSlayer.DragonSlayerHelmet>(), mod.ItemType<Items.Armor.DragonSlayer.DragonSlayerChest>(), mod.ItemType<Items.Armor.DragonSlayer.DragonSlayerLeggings>()
                }));
            if (Main.rand.Next(10) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.DragonSlayerSpear>());
        }
    }
}