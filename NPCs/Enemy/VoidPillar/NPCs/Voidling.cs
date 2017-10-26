using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.VoidPillar.NPCs {
    public class Voidling : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Voidling");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.ChaosElemental);
            npc.scale = 1;
            npc.width = 20;
            npc.height = 32;
            //npc.aiStyle = 39;
            aiType = NPCID.ChaosElemental;
            animationType = 410;
            npc.damage = 45;
            npc.defense = 25;
            npc.lifeMax = 500;
            npc.value = 10000f;
            //banner = npc.type;
            //bannerItem = mod.ItemType<Items.Banners.BlackKnightBanner>();
        }

        public override bool PreAI() {
            if (npc.ai[3] == -120) {
                npc.ai[3] = 0;
                for (int i = 0; i < 20; i++) {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke, 0, 0, 0, Color.Black);
                    Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
                    Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                    Main.dust[dust].noGravity = true;
                }
            }
            return true;
        }

        public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                if (VoidPillarHandler.ShieldStrength > 0) {
                    NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType<VoidPillar>())];
                    Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("PillarLaser"), 1, 1f);
                }
            }
        }

        public override void NPCLoot() {
            for (int i = 0; i < 20; i++) {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke, 0, 0, 0, Color.Black);
                Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }

        public override void FindFrame(int frameHeight) {
            if (Math.Abs(npc.velocity.Y) > 1f) npc.frame.Y = 5 * frameHeight;
        }

        public override void PostDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor) {
            DrakSolzUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Enemy/VoidPillar/NPCs/Voidling_GlowMask"));
        }
    }
}