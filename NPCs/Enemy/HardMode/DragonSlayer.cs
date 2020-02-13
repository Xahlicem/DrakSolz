using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode {
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
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 7500f;
            npc.knockBackResist = 0.12f;
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.DragonSlayerBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny && Main.raining)
                return SpawnCondition.OverworldHallow.Chance * 0.08f;
            else return 0f;
        }
        public override void NPCLoot() {
            for (int i = 0; i < 6; i++)
                DrakSolz.CreateGore(mod, npc, "Gores/DragonSlayer/Gore_" + i);

            DrakSolz.DropItem(npc, 25f, ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerHelmet>(), ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerChest>(), ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerLeggings>());
            DrakSolz.DropItem(npc, 12.5f, ModContent.ItemType<Items.Melee.DragonSlayerSpear>());
        }
    }
}