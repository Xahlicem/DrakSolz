using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode.Cthulhun {

    public class Cthulhun : ModNPC {
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
            npc.knockBackResist = 0.7f;
            clone = null;

            npc.damage = 40;
            npc.defense = 25;
            npc.lifeMax = 175;
            npc.value = 250f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.HollowBanner>();
        }

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_3");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_6");
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Lifegem>());
            if (Main.rand.Next(8) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Twink>());
            if (Main.rand.Next(20) == 0) Item.NewItem(npc.position, npc.width, npc.height, ItemID.Trident, 1, false, 40);
        }
    }
}