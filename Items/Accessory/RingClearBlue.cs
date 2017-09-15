using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingClearBlue : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Clear Bluestone Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n-25% Mana Cost");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.manaCost *= 0.75f;
        }
    }
}