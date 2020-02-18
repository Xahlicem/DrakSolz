using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingCloranthy : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Cloranthy");
            Tooltip.SetDefault("30% increased maximum movement speed" +
                "\n15% increased melee speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.maxRunSpeed += 0.30f;
            player.moveSpeed += 0.15f;
            player.meleeSpeed += 0.15f;
        }
    }
}