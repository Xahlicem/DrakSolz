using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Desert {
    public class Scarabyte : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scarabyte");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.IceBat);
            npc.scale *= 0.5f;
            npc.width = 30;
            npc.height = 30;
            //npc.aiStyle = 39;
            aiType = NPCID.IceBat;
            animationType = NPCID.Hellbat;
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
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 4.2f, y);
            }
        }
    }
}