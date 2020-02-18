using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingAvarice : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Avarice");
            Tooltip.SetDefault("increased souls from enemies");
        }

        public override string Texture { get { return "DrakSolz/Items/Accessory/RingBlades"; } }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().Avarice += 2;
        }
    }
}