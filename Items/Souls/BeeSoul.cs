using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class BeeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sweet Soul");
            Tooltip.SetDefault("Soul of the Queen Bee");
        }

        public BeeSoul() {
            Place = 4;
            Ticks = 52;
        }
    }
}