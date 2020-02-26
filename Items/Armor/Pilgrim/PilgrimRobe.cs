using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Pilgrim {
    [AutoloadEquip(EquipType.Body)]
    public class PilgrimRobe : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Pilgrim's Robe");
            Tooltip.SetDefault("Increases souls gathered by 10%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = ItemRarityID.Purple;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player) {
            player.GetModPlayer<DrakSolzPlayer>().Avarice += 1;
        }


        public class PilgrimRobeNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (npc.type == ModContent.NPCType<NPCs.Town.Pilgrim>()) {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.Pilgrim.PilgrimRobe>(), 1);
                }
            }
        }
    }
}