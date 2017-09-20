using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class SlimeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Colossal Soul");
            Tooltip.SetDefault("Soul of the King Slime");
        }

        public SlimeSoul() : base(0, 40, "RingTinyBeing") { }
    }
}