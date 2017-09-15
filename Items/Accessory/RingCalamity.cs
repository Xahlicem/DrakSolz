using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingCalamity : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Calamity Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n- All Defense");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.defense = -500;
            item.height = 20;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
    }
}