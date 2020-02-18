using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingSteelProt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Steel Protection");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 4;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }
    }
}