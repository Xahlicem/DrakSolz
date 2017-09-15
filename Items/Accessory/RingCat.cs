using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingCat : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silvercat Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+No Fall Damage");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.noFallDmg = true;
        }
    }
}