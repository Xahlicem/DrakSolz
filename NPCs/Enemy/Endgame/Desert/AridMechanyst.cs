using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {
    public class AridMechanyst : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arid Mechanyst");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.IceBat);
            npc.scale = 1;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.IceBat;
            animationType = NPCID.IceBat;
            npc.damage = 140;
            npc.defense = 1500;
            npc.lifeMax = 40000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.2f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.LittleMushroomBanner>();
        }
    }
}