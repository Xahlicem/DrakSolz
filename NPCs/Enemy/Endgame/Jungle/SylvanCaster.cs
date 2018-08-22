using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Jungle {
    public class SylvanCaster : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sylvan Caster");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.DarkCaster);
            npc.scale = 1;
            npc.width = 48;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.DarkCaster;
            animationType = NPCID.DarkCaster;
            npc.damage = 120;
            npc.defense = 1700;
            npc.lifeMax = 45000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.1f;
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