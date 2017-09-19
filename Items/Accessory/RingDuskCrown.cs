using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingDuskCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dusk Crown Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n-50% Mana Cost" +
                "\n-50% Life");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.defense = 0;
            item.height = 20;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.5f);
            player.manaCost *= 0.5f;

        }
    }
}