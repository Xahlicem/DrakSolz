using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalYellow : CoalItem {
        public CoalYellow() : base(COAL_YELLOW, ItemRarityID.Yellow, Item.sellPrice(0, 5, 0, 0)) {}

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Smoldering Yellow Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }
    }
}