using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.VoidPillar.NPCs {
    public class NightMare : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Night Mare");
            Main.npcFrameCount[npc.type] = 16;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Unicorn);
            npc.scale = 1;
            npc.width = 56;
            npc.height = 44;
            //npc.aiStyle = 39;
            aiType = NPCID.Unicorn;
            animationType = NPCID.Unicorn;
            npc.damage = 95;
            npc.defense = 55;
            npc.lifeMax = 1400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 0.03f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.NightMareBanner>();
        }

        public override void AI() {
            npc.timeLeft = 60;
            npc.TargetClosest();
        }

        public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                if (VoidPillarHandler.ShieldStrength > 0) {
                    NPC parent = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Enemy.VoidPillar.VoidPillar>())];
                    Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, ModContent.ProjectileType<Projectiles.PillarLaser>(), 1, 1f);
                }
            }
        }
    }
}