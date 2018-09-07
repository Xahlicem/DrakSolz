using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.NPCs.Enemy.Endgame.Ice {
    public class CrystalWisp : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Crystal Wisp");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Raven);
            npc.scale = 0.8f;
            npc.width = 30;
            npc.height = 30;
            //npc.aiStyle = 39;
            aiType = NPCID.Raven;
            animationType = NPCID.GiantBat;
            npc.damage = 150;
            npc.defense = 1500;
            npc.lifeMax = 60000;
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
                npc.velocity = new Vector2(npc.direction * 2.0f, y);
            }
        }
        public override void NPCLoot() {
            if (Main.netMode != 1) {
                float numberProjectiles = 4;
                float rotation = MathHelper.ToRadians(210);
                for (int i = 0; i < numberProjectiles; i++) {
                    Vector2 perturbedSpeed = new Vector2(-15, -15).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                    int pro = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.IceSpike, 0, 0);
                    Main.projectile[pro].scale *= 1.0f;
                    Main.projectile[pro].friendly = false;
                    Main.projectile[pro].hostile = true;
                    Main.projectile[pro].velocity *= 0.5f;
                    Main.projectile[pro].timeLeft = 120;
                }
            }
        }
    }
}