using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class SilverKnightSpear : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSpearman);
            npc.scale = 1;
            npc.width = 48;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.SolarSpearman;
            animationType = NPCID.SolarSpearman;
            npc.damage = 100;
            npc.defense = 50;
            npc.lifeMax = 1500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 7500f;
            npc.knockBackResist = 0.05f;
            banner = mod.NPCType<SilverKnight>();
            bannerItem = mod.ItemType<Items.Banners.SilverKnightBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (spawnInfo.player.GetModPlayer<DrakSolzPlayer>(mod).ZoneTowerWhitePillar) return 0.75f;
            return 0f;
        }

        /*public override void AI() {
            npc.TargetClosest(true);
            float distance = Main.player[npc.target].Distance(npc.Center);
            if (distance >= 20 && distance <= 180) {
                npc.velocity = new Vector2(npc.direction * ((Math.Abs(distance) + 1) / 20), ((Math.Abs(distance) + 1) / 20));
            }
        }*/
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_3"));
            Main.gore[g].scale = npc.scale;
            if (Main.rand.Next(40) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.SilverKnight.SilverKnightHelmet>(), mod.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>(), mod.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>()
                }));
            //if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.DragonSlayerSpear>());
        }
    }
}