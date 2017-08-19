using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingCalamity : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Calamity Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n- All Defense");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.defense = -200;
            item.height = 20;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {

        }
    }
}