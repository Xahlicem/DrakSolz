using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {

    public class HollowDog : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hollow Dog");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.width = 30;
            npc.scale *= 1.0f;
            npc.height = 30;
            npc.aiStyle = 26;
            aiType = NPCID.Wolf;
            animationType = NPCID.Hellhound;
            npc.damage = 20;
            npc.defense = 4;
            npc.lifeMax = 60;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100;
            npc.knockBackResist = 0.8f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.HollowDogBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedBoss1) {
                return SpawnCondition.OverworldNightMonster.Chance * 0.4f;
            } else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot() {
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Lifegem>());
            if (Main.rand.Next(20) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.HomewardBone>());
        }

    }
}