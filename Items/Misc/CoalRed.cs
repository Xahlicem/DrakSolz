using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalRed : CoalItem {
        public CoalRed() : base(COAL_RED, ItemRarityID.LightRed, Item.sellPrice(0, 1, 0, 0)) {}

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Red Hot Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }
    }
}