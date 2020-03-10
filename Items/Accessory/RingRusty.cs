using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingRusty : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rusty Ring");
            Tooltip.SetDefault("Increased mobility in water");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.ignoreWater = true;
        }
    }
}