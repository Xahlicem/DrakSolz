using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {
    public class BlackSolus : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Solus");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Wraith);
            npc.scale = 1;
            npc.width = 80;
            npc.height = 80;
            //npc.aiStyle = 39;
            aiType = NPCID.Wraith;
            animationType = NPCID.Wraith;
            npc.damage = 150;
            npc.defense = 1300;
            npc.lifeMax = 100000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.05f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.LittleMushroomBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 1.8f, y);
            }
        }
    }
}