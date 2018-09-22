using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.HardMode {
    public class ManEaterShell : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Man-Eater Shell");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Crab);
            npc.scale = 1;
            npc.width = 24;
            npc.height = 38;
            //npc.aiStyle = 39;
            aiType = NPCID.WalkingAntlion;
            animationType = NPCID.Crab;
            npc.damage = 60;
            npc.defense = 30;
            npc.lifeMax = 700;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1000f;
            npc.knockBackResist = 0.08f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.ManEaterShellBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny)
                return SpawnCondition.Ocean.Chance * 0.15f;
            else return 0f;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit) {
            player.AddBuff(mod.BuffType<Buffs.SlipperyBuff>(), 600, true);
        }
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ManEaterShell_Gore_1"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ManEaterShell_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ManEaterShell_Gore_3"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ManEaterShell_Gore_4"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ManEaterShell_Gore_5"));
            Main.gore[g].scale = npc.scale;
            /*if (Main.rand.Next(4) == 0)
                Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, new int[] {
                    mod.ItemType<Items.Armor.DragonSlayer.DragonSlayerHelmet>(), mod.ItemType<Items.Armor.DragonSlayer.DragonSlayerChest>(), mod.ItemType<Items.Armor.DragonSlayer.DragonSlayerLeggings>()
                }));*/
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Twink>());
        }
    }
}