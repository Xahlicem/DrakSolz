using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingBinding : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Binding");
            Tooltip.SetDefault("increases minimum health by 40");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().Binding += 40;
        }
    }
}