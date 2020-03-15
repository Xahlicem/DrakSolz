using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingEstus : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Estus Ring");
            Tooltip.SetDefault("Increased healing and cleansing from Estus flasks");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().EstusHealth += 1;
        }
    }
}