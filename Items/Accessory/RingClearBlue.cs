using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingClearBlue : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Clear Bluestone Ring");
            Tooltip.SetDefault("25% decreased mana cost");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.manaCost *= 0.75f;
        }
    }
}