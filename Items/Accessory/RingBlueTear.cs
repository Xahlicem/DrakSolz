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
            int life = 0;
            if (player.statLifeMax2 <= 20) life = 15;
            else if (player.statLifeMax2 <= 100) life = 20;
            else life = (int) (player.statLifeMax2 * 0.2f);

            if (player.statLife <= life) {
                player.statDefense += 20;
            }
        }
    }
}