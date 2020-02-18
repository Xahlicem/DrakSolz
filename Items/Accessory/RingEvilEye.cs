using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingEvilEye : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Evil Eye Ring");
            Tooltip.SetDefault("Heals you when you kill an enemy");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().EvilEye = true;
        }
    }
}