using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingAvarice : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Avarice");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+Souls");
        }

        public override string Texture { get { return "DrakSolz/Items/Accessory/RingBlades"; } }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().Avarice += 2;
        }
    }
}