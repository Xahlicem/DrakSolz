using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {
    public class Juggernaut : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Juggernaut");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Hellhound);
            npc.scale = 0.8f;
            npc.width = 62;
            npc.height = 70;
            //npc.aiStyle = 39;
            aiType = NPCID.Hellhound;
            animationType = NPCID.Hellhound;
            npc.damage = 170;
            npc.defense = 2200;
            npc.lifeMax = 150000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.07f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.LittleMushroomBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 2, y);
            }
        }
    }
}