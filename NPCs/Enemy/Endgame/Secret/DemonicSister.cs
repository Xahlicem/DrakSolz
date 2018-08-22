using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Endgame.Secret {

    public class DemonicSister : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Demonic Sister");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.BlueArmoredBones);
            npc.width = 20;
            npc.scale *= 1.6f;
            npc.height = 40;
            npc.aiStyle = 3;
            aiType = NPCID.SolarSpearman;
            animationType = NPCID.BlackRecluse;
            npc.damage = 200;
            npc.defense = 1500;
            npc.lifeMax = 50000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1000000;
            npc.knockBackResist = 0.9f;
            //banner = npc.type;
            //bannerItem = mod.ItemType<Items.Banners.HollowDogBanner>();
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