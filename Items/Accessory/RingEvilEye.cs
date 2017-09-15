using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingEvilEye : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Evil Eye Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+Heals you when you kill an enemy");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().EvilEye = true;
        }
    }
}