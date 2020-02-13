using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Hallow {
    public class Valekeeper : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Valekeeper");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Unicorn);
            npc.scale = 0.8f;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.Unicorn;
            animationType = NPCID.WalkingAntlion;
            npc.damage = 120;
            npc.defense = 1500;
            npc.lifeMax = 65000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.1f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.HolyBanners.ValekeeperBanner>();
        }
    }
}