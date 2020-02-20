using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalYellow : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Smoldering Yellow Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 8;
        }

        public class CoalYellowGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(3) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.HardMode.DragonSlayer>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Misc.CoalYellow>(), 1);
                    }
                }
            }
        }
    }
}