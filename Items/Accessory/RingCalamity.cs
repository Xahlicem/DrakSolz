using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingCalamity : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Calamity Ring");
            Tooltip.SetDefault("Removes all defense");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.defense = -500;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }
    }
}