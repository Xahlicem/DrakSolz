using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class SkeletronPrimeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Apocalyptic Soul");
            Tooltip.SetDefault("Soul of Skeletron Prime");
        }

        public SkeletronPrimeSoul() {
            Place = 10;
            Ticks = 100;
        }
    }
}