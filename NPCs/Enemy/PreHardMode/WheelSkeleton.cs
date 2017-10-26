using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {

    public class WheelSkeleton : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wheel Skeleton");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults() {
            npc.width = 30;
            npc.scale *= 1.0f;
            npc.height = 30;
            npc.aiStyle = 26;
            aiType = NPCID.Tumbleweed;
            animationType = NPCID.Tumbleweed;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 110;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100;
            npc.knockBackResist = 1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.WheelSkeletonBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedBoss3) {
                return SpawnCondition.OverworldNightMonster.Chance * 0.12f;
            } else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot() {
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.BoneWheel>());
        }

    }
}