using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode {
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
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 10000f;
            npc.knockBackResist = 1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.DesertSorceressBanner>();
            npc.buffImmune[BuffID.Confused] = false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny)
                return SpawnCondition.DesertCave.Chance * 0.15f;
            else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit) {
            player.AddBuff(BuffID.Lovestruck, 300, true);
        }

        public override void NPCLoot() {
            if (Main.hardMode && Main.rand.Next(10) == 0) 
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] { 
                    mod.ItemType<Items.Armor.DesertSorceress.SorceressHood>(), mod.ItemType<Items.Armor.DesertSorceress.SorceressSkirt>(), mod.ItemType<Items.Armor.DesertSorceress.SorceressTop>() 
                }));
            if (Main.rand.Next(50) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Magic.Pyro.FlameFan>());
        }
    }
}