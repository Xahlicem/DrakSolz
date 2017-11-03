using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class RingedKnight : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ringed Knight");
            Main.npcFrameCount[npc.type] = 17;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.SolarSolenian);
            npc.scale = 1;
            npc.width = 40;
            npc.height = 40;
            //npc.aiStyle = 39;
            aiType = NPCID.SolarSolenian;
            animationType = NPCID.SolarSolenian;
            npc.damage = 95;
            npc.defense = 55;
            npc.lifeMax = 1400;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 0.03f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.RingedKnightBanner>();
        }
        public override void PostDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor) {
            DrakSolzUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Enemy/RingedKnight_GlowMask"), -4f);
        }

        /*public override void NPCLoot() {
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
            Item.NewItem(npc.Center, npc.width, npc.height, mod.ItemType<Items.Misc.Titanite>(), Main.rand.Next(1, 2));
        }*/
    }
}