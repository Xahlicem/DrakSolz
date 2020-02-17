using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Dungeon {
    public class Bladeseeker : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bladeseeker");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.WalkingAntlion);
            npc.scale = 1;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.WalkingAntlion;
            animationType = NPCID.WalkingAntlion;
            npc.damage = 180;
            npc.defense = 2000;
            npc.lifeMax = 70000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.2f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.BladeseekerBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 2.0f, y);
            }
        }
    }
}