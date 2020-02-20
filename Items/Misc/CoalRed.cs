using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalRed : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Red Hot Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
        }

        public class CoalRedGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(10) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Spinwheel>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Misc.CoalRed>(), 1);
                    }
                }
            }
        }
    }
}