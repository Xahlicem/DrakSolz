using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingDuskCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dusk Crown Ring");
            Tooltip.SetDefault("50% decreased mana cost" +
                "\nDecreases maximum life by 50%");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.defense = 0;
            item.height = 20;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statLifeMax2 = (int) (player.statLifeMax2 * 0.5f);
            player.manaCost *= 0.5f;

        }
    }
}