using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {
    public class Hexclaw : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hexclaw");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Wolf);
            npc.scale = 0.8f;
            npc.width = 80;
            npc.height = 50;
            //npc.aiStyle = 39;
            aiType = NPCID.Wolf;
            animationType = NPCID.FlyingAntlion;
            npc.damage = 160;
            npc.defense = 1300;
            npc.lifeMax = 30000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.2f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.CorruptBanners.HexclawBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 2.8f, y);
            }
        }
    }
}