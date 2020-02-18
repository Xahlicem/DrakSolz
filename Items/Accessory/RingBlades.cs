using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingBlades : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Blades");
            Tooltip.SetDefault("5% increased damage" +
                "\n5% increased critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.allDamage += 0.05f;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
            player.rangedCrit += 5;
        }
    }
}