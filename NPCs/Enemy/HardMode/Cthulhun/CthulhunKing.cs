using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode.Cthulhun {

    public class CthulhunKing : ModNPC {
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
            npc.knockBackResist = 0.9f;
            clone = null;

            npc.damage = 70;
            npc.defense = 32;
            npc.lifeMax = 900;
            npc.value = 1000f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.CthulhunBanner>();
        }

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit) {
            player.AddBuff(ModContent.BuffType<Buffs.SlipperyBuff>(), 480, true);
        }

        public override void NPCLoot() {
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_1");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_0");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_4");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_5");
            DrakSolz.CreateGore(mod, npc, "Gores/Cthulhun/Gore_6");
            if (Main.rand.Next(1) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Misc.CthulhunTentacle>(), Main.rand.Next(7, 10));
            if (Main.rand.Next(2) == 0) Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Misc.Twink>());
            if (Main.rand.Next(10) == 0) Item.NewItem(npc.position, npc.width, npc.height, ItemID.Trident, 1, false, 81);
        }
    }
}