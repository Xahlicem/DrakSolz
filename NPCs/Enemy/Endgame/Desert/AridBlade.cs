using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {
    public class AridBlade : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arid Blade");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.EnchantedSword);
            npc.scale = 1;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.EnchantedSword;
            animationType = NPCID.EnchantedSword;
            npc.damage = 160;
            npc.defense = 1700;
            npc.lifeMax = 40000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.2f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.LittleMushroomBanner>();
        }
    }
}