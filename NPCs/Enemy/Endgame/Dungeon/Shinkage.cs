using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Dungeon {
    public class Shinkage : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shinkage");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Zombie);
            npc.scale = 0.8f;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            npc.damage = 180;
            npc.defense = 2000;
            npc.lifeMax = 70000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.2f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.ShinkageBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 3.0f, y);
            }
        }
    }
}