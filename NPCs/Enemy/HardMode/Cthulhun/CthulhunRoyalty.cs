using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode.Cthulhun {

    public class CthulhunRoyalty : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cthulhun");
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults() {
            npc.aiStyle = 3;
            aiType = NPCID.RustyArmoredBonesAxe;
            animationType = NPCID.RustyArmoredBonesAxe;

            NPC clone = new NPC();
            clone.CloneDefaults(NPCID.RustyArmoredBonesAxe);
            npc.width = clone.width;
            npc.height = clone.height;
            npc.HitSound = clone.HitSound;
            npc.DeathSound = clone.DeathSound;
            npc.knockBackResist = 0.8f;
            clone = null;

            npc.damage = 55;
            npc.defense = 32;
            npc.lifeMax = 300;
            npc.value = 500f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.HollowBanner>();
        }

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_2");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_4");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_6");
            if (Main.rand.Next(3) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Lifegem>());
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Twink>());
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, ItemID.Trident);
        }
    }
}