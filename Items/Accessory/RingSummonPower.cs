using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingSummonPower : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Summoner's Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+20% Minion Damage");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.minionDamage += 0.20f;
        }
    }
}