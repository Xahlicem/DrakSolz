using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingThorns : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Thorns");
            Tooltip.SetDefault("Returns damage to attackers");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 2;
            item.value = Item.buyPrice(0, 17, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.thorns += 0.50f;
        }
    }
}