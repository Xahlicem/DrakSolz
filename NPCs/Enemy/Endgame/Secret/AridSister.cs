using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Secret {

    public class AridSister : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arid Sister");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Crab);
            npc.scale *= 1.6f;
            npc.width = 20;
            npc.height = 30;
            //npc.aiStyle = 39;
            aiType = NPCID.Crab;
            animationType = NPCID.Crab;
            npc.damage = 200;
            npc.defense = 1500;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1000000;
            npc.knockBackResist = 0.1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.AridBanner>();
        }

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction * -1;
        }
                public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 100f) {
                npc.velocity = new Vector2(npc.direction * 3, y);
            }
        }
        public override void NPCLoot() {
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Lifegem>());
            if (Main.rand.Next(20) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.HomewardBone>());
        }

    }
}