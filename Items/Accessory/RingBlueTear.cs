using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingBlueTear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Blue Tearstone Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+20 Defense when near death");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.statLife <= (player.statLifeMax * 0.2f)) {
                item.defense = 20;
            } else { item.defense = 1; }

        }

        public override bool CanEquipAccessory(Player player, int slot) {
            item.defense = 20;
            return base.CanEquipAccessory(player, slot);
        }
    }
}