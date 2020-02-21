using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalBlue : CoalItem {
        public CoalBlue() : base(COAL_BLUE, ItemRarityID.Blue, Item.sellPrice(0, 10, 0, 0)) {}

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Brilliant Blue Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }
    }
}