using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Dungeon {
    public class SilverKnightSpear : SilverKnight {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSpearman);
            npc.scale = 1;
            npc.width = 48;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.SolarSpearman;
            animationType = NPCID.SolarSpearman;
            npc.damage = 85;
            npc.defense = 625;
            npc.lifeMax = 6000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 7500f;
            npc.knockBackResist = 0.05f;
            banner = ModContent.NPCType<SilverKnight>();
            bannerItem = ModContent.ItemType<Items.Banners.SilverKnightBanner>();
        }

        public override void NPCLoot() {
            base.NPCLoot();
            //DrakSolz.DropItem(npc, 12.5f, ModContent.ItemType<Items.Ranged.DragonslayerGreatbow>());
        }
    }
}