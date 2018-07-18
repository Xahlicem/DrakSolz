using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class DestSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cataclysmic Soul");
            Tooltip.SetDefault("Soul of the Destroyer");
        }

        public DestSoul() : base(7, 80000, "RingHavels") { }
    }
}