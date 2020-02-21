using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CoalLord : CoalItem {
        public CoalLord() : base(COAL_LORD, ItemRarityID.Red, Item.sellPrice(0, 20, 0, 0)) {}

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lord's Coal");
            Tooltip.SetDefault("Coal used for crafting new equipment.");
        }
    }
}