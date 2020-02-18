using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingCat : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silvercat Ring");
            Tooltip.SetDefault("Negates fall damage");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.noFallDmg = true;
        }
    }
}