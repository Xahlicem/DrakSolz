using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Pilgrim {
    [AutoloadEquip(EquipType.Head)]
    public class PilgrimHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pilgrim's Hood");
            Tooltip.SetDefault("Increases souls gathered by 10%");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = ItemRarityID.Purple;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player) {
            player.GetModPlayer<DrakSolzPlayer>().Avarice += 1;
        }
        public override bool DrawHead() {
            return false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Pilgrim.PilgrimRobe>() && legs.type == ModContent.ItemType<Items.Armor.Pilgrim.PilgrimWaistcloth>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Increases souls gathered by 20%");
            player.GetModPlayer<DrakSolzPlayer>().Avarice += 2;
        }

        public class PilgrimHoodNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (npc.type == ModContent.NPCType<NPCs.Town.Pilgrim>()) {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.Pilgrim.PilgrimHood>(), 1);
                }
            }
        }
    }
}