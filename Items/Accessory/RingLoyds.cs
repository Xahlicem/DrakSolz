using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingLoyds : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Loyd's Sword Ring");
            Tooltip.SetDefault("20% increased damage at max life");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.statLife >= player.statLifeMax2) {
                player.allDamage += 0.20f;
            }
        }
    }
}