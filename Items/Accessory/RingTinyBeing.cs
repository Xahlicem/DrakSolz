using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingTinyBeing : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tiny Being's Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+20 Max Life");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statLifeMax2 += 20;
        }
    }
}