using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalLord : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lord's Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = 10;
        }

        public class CoalLordGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (npc.type == ModContent.NPCType<NPCs.Enemy.Boss.AbyssStalker>()) {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Misc.CoalLord>(), 1);
                }
            }
        }
    }
}