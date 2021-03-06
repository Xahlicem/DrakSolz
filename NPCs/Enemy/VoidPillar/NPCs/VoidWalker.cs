using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.VoidPillar.NPCs {
    public class VoidWalker : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Void Walker");
            Main.npcFrameCount[npc.type] = 25;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Medusa);
            npc.scale = 1;
            npc.width = 38;
            npc.height = 46;
            //npc.aiStyle = 39;
            aiType = NPCID.Medusa;
            animationType = NPCID.Medusa;
            npc.damage = 95;
            npc.defense = 55;
            npc.lifeMax = 1400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 0.03f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.VoidWalkerBanner>();
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

        public override void PostDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor) {
            DrakSolzUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Enemy/VoidPillar/NPCs/VoidWalker_GlowMask"), -6f);
        }
    }
}