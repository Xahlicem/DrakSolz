using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class DestSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cataclysmic Soul");
            Tooltip.SetDefault("Soul of the Destroyer");
        }

        public DestSoul() {
            Place = 7;
            Ticks = 100;
        }
    }
}