using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.WhitePillar {
    public class BlackKnight : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Knight");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSpearman);
            npc.scale = 1;
            npc.width = 40;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.SolarSpearman;
            animationType = NPCID.SolarSpearman;
            npc.damage = 120;
            npc.defense = 60;
            npc.lifeMax = 1700;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 0.03f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.BlackKnightBanner>();
        }

        public override void AI() {
            npc.timeLeft = 60;
            npc.TargetClosest();
        }
        
        public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                if (WhitePillarHandler.ShieldStrength > 0) {
                    NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("WhitePillar"))];
                    Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("PillarLaser"), 1, 1f);
                }
            }
        }
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackKnight_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackKnight_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BlackKnight_Gore_3"));
            Main.gore[g].scale = npc.scale;
            if (Main.rand.Next(15) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.BlackKnight.BlackKnightHelmet>(), mod.ItemType<Items.Armor.BlackKnight.BlackKnightArmor>(), mod.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings>()
                }));
            //if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.DragonSlayerSpear>());
        }
    }
}