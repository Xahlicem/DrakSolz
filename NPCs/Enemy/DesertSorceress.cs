using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class DesertSorceress : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Desert Sorceress");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults() {
            npc.width = 24;
            npc.scale *= 1.1f;
            npc.height = 44;
            npc.aiStyle = 8;
            aiType = NPCID.DiabolistWhite;
            animationType = NPCID.DiabolistWhite;
            npc.damage = 60;
            npc.defense = 25;
            npc.lifeMax = 750;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 50000f;
            npc.knockBackResist = 1f;
            npc.buffImmune[BuffID.Confused] = false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return SpawnCondition.Mummy.Chance * 0.5f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }

        /*public override void NPCLoot() {
            if (Main.hardMode && Main.rand.Next(10) == 0) 
                Utils.SelectRandom(Main.rand, new int[] { 
                    mod.ItemType<Items.Armor.DesertSorceress.SorceressHood>(), mod.ItemType<Items.Armor.DesertSorceress.SorceressSkirt>(), mod.ItemType<Items.Armor.DesertSorceress.SorceressTop>() 
                });
        }*/
    }
}