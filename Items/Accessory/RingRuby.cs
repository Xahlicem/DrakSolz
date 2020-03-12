using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingRuby : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Aldrich's Ruby");
            Tooltip.SetDefault("Restore life on melee attack");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.attackCD == 1){
                player.statLife += (1);
                player.HealEffect(1);
            }
        }
    }
}