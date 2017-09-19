using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class WallSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cadaverous Soul");
            Tooltip.SetDefault("Soul of the Wall of Flesh");
        }

        public WallSoul() {
            Place = 6;
            Ticks = 80;
        }
    }
}