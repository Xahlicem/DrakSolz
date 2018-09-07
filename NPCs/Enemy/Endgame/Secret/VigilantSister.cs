using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Secret {

    public class VigilantSister : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Vigilant Sister");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.width = 20;
            npc.scale *= 1.6f;
            npc.height = 40;
            npc.aiStyle = 44;
            aiType = NPCID.FlyingAntlion;
            animationType = NPCID.Crab;
            npc.damage = 200;
            npc.defense = 1500;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1000000;
            npc.knockBackResist = 0.8f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.VigilantBanner>();
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction * -1;
        }
        public override void NPCLoot() {
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Lifegem>());
            if (Main.rand.Next(20) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.HomewardBone>());
        }

    }
}