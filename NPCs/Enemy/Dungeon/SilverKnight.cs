using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Dungeon {
    public class SilverKnight : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight");
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
            npc.damage = 80;
            npc.defense = 650;
            npc.lifeMax = 7000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 7000f;
            npc.knockBackResist = 0.06f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.SilverKnightBanner>();
        }
        
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SilverKnight_Gore_3"));
            Main.gore[g].scale = npc.scale;
            if (Main.rand.Next(75) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.SilverKnight.SilverKnightHelmet>(), mod.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>(), mod.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>()
                }));
            //if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.DragonSlayerSpear>());
            if (Main.rand.Next(8) == 0) {
                Item.NewItem(npc.Center, npc.width, npc.height, mod.ItemType<Items.Misc.Titanite>());
            }
        }
    }

}