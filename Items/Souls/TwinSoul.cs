using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class TwinSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Entangled Soul");
            Tooltip.SetDefault("Soul of the Twins");
        }

        public override void SetDefaults() {
            Place = 30;
            Ticks = 104;
        }
    }
}