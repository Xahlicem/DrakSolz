using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class SlimeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Colossal Soul");
            Tooltip.SetDefault("Soul of the King Slime");
        }

        public SlimeSoul() {
            Place = 0;
            Ticks = 40;
        }
    }
}