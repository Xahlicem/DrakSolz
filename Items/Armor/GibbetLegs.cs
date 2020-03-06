using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Legs)]
    public class GibbetLegs : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gibbet Legs");
            Tooltip.SetDefault("Kill!");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 35;
        }
        public override void UpdateEquip(Player player) { }
        public override bool DrawLegs() {
            return false;
        }
    }
}