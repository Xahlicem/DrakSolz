using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
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

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.GetModPlayer<DrakSolzPlayer>(mod).ZoneTowerWhitePillar) return 0.2f;
            return 0f;
        }

        /*public override void AI() {
            npc.TargetClosest(true);
            float distance = Main.player[npc.target].Distance(npc.Center);
            if (distance >= 25 && distance <= 300) {
                npc.velocity = new Vector2(npc.direction * ((Math.Abs(distance) + 1) / 25), ((Math.Abs(distance) + 1) / 25));
            }
        }*/
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