using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {
    public class Chicken : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chicken");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Squirrel);
            npc.scale = 1;
            npc.width = 24;
            npc.height = 24;
            //npc.aiStyle = 39;
            aiType = NPCID.Squirrel;
            animationType = NPCID.Squirrel;
            npc.damage = 0;
            npc.defense = 9999;
            npc.lifeMax = 30;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.5f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.ChickenBanner>();
        }

        const int AI_Timer_Slot = 0;

        public float AI_Timer {
            get { return npc.localAI[AI_Timer_Slot]; }
            set { npc.localAI[AI_Timer_Slot] = value; }
        }
        public override void AI() {
            AI_Timer++;

            if (AI_Timer >= 120) {
                if (npc.life <= 15) {
                    npc.TargetClosest();
                    if (Main.netMode != 1) {
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.ChickenEgg>(), 10, 1f);
                   Main.NewText("BAWK!", 255, 0, 0);
                    }
                }
                AI_Timer = 0;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.OverworldDayBirdCritter.Chance * 0.05f;
        }
        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_0");
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_1");
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_2");
            DrakSolz.CreateGore(mod, npc, "Gores/Chicken/Gore_3");
        }
    }
}