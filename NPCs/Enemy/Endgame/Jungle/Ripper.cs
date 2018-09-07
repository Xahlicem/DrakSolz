using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {
    public class Ripper : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ripper");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Crab);
            npc.scale = 0.8f;
            npc.width = 50;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.Crab;
            animationType = NPCID.WalkingAntlion;
            npc.damage = 140;
            npc.defense = 1400;
            npc.lifeMax = 30000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.3f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.LittleMushroomBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 3, y);
            }
        }
    }
}