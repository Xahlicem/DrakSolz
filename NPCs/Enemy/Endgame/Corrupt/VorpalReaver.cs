using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Corrupt {
    public class VorpalReaver : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Vorpal Reaver");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Crab);
            npc.scale = 1;
            npc.width = 60;
            npc.height = 60;
            //npc.aiStyle = 39;
            aiType = NPCID.Crab;
            animationType = NPCID.Crab;
            npc.damage = 120;
            npc.defense = 1450;
            npc.lifeMax = 65000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 20f;
            npc.knockBackResist = 0.1f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.CorruptBanners.VorpalReaverBanner>();
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 20f) {
                npc.velocity = new Vector2(npc.direction * 2.2f, y);
            }
        }
        public override void NPCLoot() {
                if (Main.netMode != 1) {
                    float numberProjectiles = 10;
                    float rotation = MathHelper.ToRadians(10);
                    for (int i = 0; i < numberProjectiles; i++) {
                        int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 15 * (Main.rand.NextFloat() - 0.5f), -15 * (Main.rand.NextFloat() + 0.5f), ModContent.ProjectileType<Projectiles.VorpalDaggerProj>(), npc.damage / 2, 1f);
                        Main.projectile[proj].scale *= 0.8f;
                        Main.projectile[proj].friendly = false;
                        Main.projectile[proj].hostile = true;
                        Main.projectile[proj].velocity *= 0.35f;
                    }
            }
        }
    }
}