using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingBlueTear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Blue Tearstone Ring");
            Tooltip.SetDefault("20 defense when near death");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.statLife <= (player.statLifeMax) * 0.5f) {
                player.statDefense += 20;
            }
        }
    }
}