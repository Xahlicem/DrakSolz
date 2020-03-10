using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingAgape : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Agape");
            Tooltip.SetDefault("stronger pull for souls and other items");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().Agape = true;
            player.manaMagnet = true;
            player.goldRing = true;
            player.AddBuff(BuffID.Heartreach, 1, true);
        }
    }
}