using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Body)]
    public class GibbetBody : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Gibbet Body");
            Tooltip.SetDefault("Murder!");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 40;
        }
        public override void UpdateEquip(Player player) { }

        public override bool DrawBody() {
            return false;
        }
    }
}