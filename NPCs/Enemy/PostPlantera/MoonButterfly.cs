using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PostPlantera {
    public class MoonButterfly : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Butterfly");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Moth);
            npc.scale = 1.5f;
            npc.width = 24;
            //npc.aiStyle = 39;
            aiType = NPCID.Moth;
            animationType = NPCID.Moth;
            npc.height = 70;
            npc.damage = 50;
            npc.defense = 40;
            npc.lifeMax = 6000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 22500f;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.MoonButterflyBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedGolemBoss)
                return SpawnCondition.OverworldNightMonster.Chance * 0.075f;
            else return 0f;
        }

        const int AI_Timer_Slot = 3;

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        const int Angle_Slot = 2;

        public float Angle {
            get { return npc.localAI[Angle_Slot]; }
            set { npc.localAI[Angle_Slot] = value; }
        }

        public override void AI() {
            npc.timeLeft = 60;
            npc.TargetClosest();
            if (npc.HasValidTarget) {
                Vector2 target = Main.player[npc.target].Center;
                target.Y -= 8;
                float dist = npc.Distance(target);
                if (dist < 1000)
                    AI_Timer++;
                npc.FaceTarget();

                Angle = MathHelper.ToDegrees(npc.AngleTo(target));

                Vector2 vector = target - npc.Center;
                DrakSolz.AdjustMagnitude(ref vector, 12.5f);
                if (Main.netMode != 1 && AI_Timer == 120 || Main.netMode != 1 && AI_Timer > 140) {
                    float numberProjectiles = 3;
                    float rotation = MathHelper.ToRadians(30);
                    for (int i = 0; i < numberProjectiles; i++) {
                        Vector2 perturbedSpeed = new Vector2(vector.X, vector.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                        int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X * 12, perturbedSpeed.Y * 12, ModContent.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), npc.damage, 0);
                        Main.projectile[proj].scale *= 0.4f;
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                    }
                    /*int proj = Projectile.NewProjectile(npc.Center, vector, ModContent.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), npc.damage, 0);
                    Main.projectile[proj].friendly = false;
                    Main.projectile[proj].hostile = true;
                    Main.projectile[proj].netUpdate = true;*/
                    if (Main.netMode != 1 && AI_Timer > 140) {
                        AI_Timer = 0;
                    }
                }
                npc.netUpdate = true;
            }
        }

        public override void NPCLoot() {
            for (int i = 0; i < 6; i++)
                DrakSolz.CreateGore(mod, npc, "Gores/MoonButterfly/Gore_" + i);

            DrakSolz.DropItem(npc, 100f, ModContent.ItemType<Items.Misc.Twink>());
            DrakSolz.DropItem(npc, 20f, ModContent.ItemType<Items.Misc.MoonButterflyHorn>());
        }
        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 26.5f / magnitude;

            return vector;
        }
    }
}