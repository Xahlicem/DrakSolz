using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode {
    public class Humanity : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Humanity");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.CursedSkull);
            npc.scale = 1f;
            npc.width = 25;
            npc.height = 40;
            npc.aiStyle = 10;
            aiType = NPCID.CursedSkull;
            animationType = NPCID.Wraith;
            npc.noTileCollide = true;
            npc.damage = 80;
            npc.defense = 1;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 250f;
            npc.knockBackResist = 0f;
            npc.alpha = 50;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HumanityBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny)
                return SpawnCondition.Cavern.Chance * 0.25f;
            else return 0f;
        }
        public override void NPCLoot() {
            if (Main.rand.Next(150) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Summon.EffigyStaff>());
        }
    }
}