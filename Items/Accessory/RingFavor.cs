using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingFavor : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Favor and Protection");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+40 Max Life" +
                "\n+40 Max Mana" +
                "\n+15% Move Speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statManaMax2 += 40;
            player.statLifeMax2 += 40;
            player.maxRunSpeed += 0.15f;
            player.moveSpeed += 0.15f;
        }
    }
}