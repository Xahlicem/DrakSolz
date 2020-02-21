using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalWhite : CoalItem {
        public CoalWhite() : base(COAL_WHITE, ItemRarityID.White, Item.sellPrice(0, 2, 0, 0)) {}

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bright White Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }
    }
}