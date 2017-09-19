using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class Lifegem : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lifegem");
            Tooltip.SetDefault("Recovers life over time.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Mushroom);
            item.width = refItem.width;
            item.height = refItem.height;
            item.useStyle = refItem.useStyle;
            item.UseSound = refItem.UseSound;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.rare = 0;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.Regeneration, 600);

            int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
            if (index != -1) player.buffTime[index] -= 30;
            return true;
        }

        public class LifegemGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(5) == 0) {
                    if (npc.type == NPCID.Zombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.ArmedZombie ||
                        npc.type == NPCID.BigBaldZombie || npc.type == NPCID.ZombieDoctor ||
                        npc.type == NPCID.ArmedZombieEskimo || npc.type == NPCID.SlimedZombie ||
                        npc.type == NPCID.SmallZombie || npc.type == NPCID.ArmedZombieSlimed ||
                        npc.type == NPCID.BigFemaleZombie || npc.type == NPCID.BigSlimedZombie ||
                        npc.type == NPCID.ArmedZombiePincussion || npc.type == NPCID.ArmedZombieSwamp ||
                        npc.type == NPCID.ArmedZombieTwiggy || npc.type == NPCID.BigPincushionZombie ||
                        npc.type == NPCID.BigSwampZombie || npc.type == NPCID.BigTwiggyZombie ||
                        npc.type == NPCID.BigZombie || npc.type == NPCID.SmallBaldZombie ||
                        npc.type == NPCID.SmallFemaleZombie || npc.type == NPCID.SmallPincushionZombie ||
                        npc.type == NPCID.SmallSlimedZombie || npc.type == NPCID.SmallSwampZombie ||
                        npc.type == NPCID.SmallTwiggyZombie || npc.type == NPCID.SwampZombie ||
                        npc.type == NPCID.TwiggyZombie || npc.type == NPCID.PincushionZombie ||
                        npc.type == NPCID.FemaleZombie || npc.type == NPCID.ArmedZombieCenx) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Misc.Lifegem>(), 1);

                    }
                }
            }
        }

    }
}