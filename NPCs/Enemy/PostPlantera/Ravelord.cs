using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PostPlantera {
    public class Ravelord : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ravelord");
            Main.npcFrameCount[npc.type] = 17;
        }

        public override void SetDefaults() {
            npc.width = 55;
            npc.scale *= 1.5f;
            npc.height = 65;
            npc.aiStyle = 3;
            aiType = NPCID.PossessedArmor;
            animationType = NPCID.PossessedArmor;
            npc.damage = 120;
            npc.defense = 55;
            npc.lifeMax = 5500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 50000f;
            npc.knockBackResist = 0.1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.RavelordBanner>();
            npc.buffImmune[BuffID.Confused] = false;
        }
        const int AI_Timer_Slot = 0;

        public float AI_Timer {
            get { return npc.localAI[AI_Timer_Slot]; }
            set { npc.localAI[AI_Timer_Slot] = value; }
        }

        public override void AI() {
            AI_Timer++;

            if (AI_Timer >= 300) {
                npc.TargetClosest();
                if (Main.netMode != 1) {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 16, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.SkeletonBone>(), npc.damage / 10, 1f);
                }
                AI_Timer = 0;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedGolemBoss) {
                return SpawnCondition.Cavern.Chance * 0.15f;
            } else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot() {
            if (Main.netMode != 1) {
                for (int i = 0; i < 10; i++)
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10 * (Main.rand.NextFloat() - 0.5f), -3 * (Main.rand.NextFloat() + 0.5f), mod.ProjectileType<Projectiles.SkeletonBone>(), npc.damage / 10, 1f);
            }
            if (Main.rand.Next(20) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.GravelordSword>());
        }
    }
}