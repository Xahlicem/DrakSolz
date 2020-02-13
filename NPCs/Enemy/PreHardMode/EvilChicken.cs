using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {

    public class EvilChicken : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Evil Chicken");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.width = 30;
            npc.scale *= 1.0f;
            npc.height = 30;
            npc.aiStyle = 17;
            aiType = NPCID.Vulture;
            animationType = NPCID.FlyingFish;
            npc.damage = 100;
            npc.defense = 10;
            npc.lifeMax = 10000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000;
            npc.knockBackResist = 0.95f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.ChickenBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return 0f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_4");
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_6");
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_7");
        }

    }
}