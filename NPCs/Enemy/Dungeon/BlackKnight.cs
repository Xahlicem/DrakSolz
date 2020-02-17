using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Dungeon {
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
            npc.damage = 95;
            npc.defense = 700;
            npc.lifeMax = 10000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 0.03f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.BlackKnightBanner>();
        }

        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/BlackKnight/Head");
            DrakSolz.CreateGore(mod, npc, "Gores/BlackKnight/Body");
            DrakSolz.CreateGore(mod, npc, "Gores/BlackKnight/Legs");
            DrakSolz.DropItem(npc, 12.5f, ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightHelmet>(), ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightArmor>(), ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings>());
            DrakSolz.DropItem(npc, 100f, ModContent.ItemType<Items.Misc.Titanite>(), Main.rand.Next(1, 2));
        }
    }
}