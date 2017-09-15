using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingMagicPower : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Scholar's Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+20% Magic Damage");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.magicDamage += 0.20f;
        }
    }
}