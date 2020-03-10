using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingKnuckleBrace : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bracing Knuckle Ring");
            Tooltip.SetDefault("Improves mining speed and melee knockback");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.pickSpeed += 0.25f;
            player.kbGlove = true;
        }
    }
}