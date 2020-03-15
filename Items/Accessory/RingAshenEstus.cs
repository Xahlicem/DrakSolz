using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingAshenEstus : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ashen Estus Ring");
            Tooltip.SetDefault("Restore mana from Estus flasks");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().EstusMana += 10;
        }
    }
}