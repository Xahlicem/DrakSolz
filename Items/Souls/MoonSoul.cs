using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class MoonSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Luminous Soul");
            Tooltip.SetDefault("Soul of the Moon Lord");
        }

        public MoonSoul() : base(15, 750000, "RingTinyBeing") { }
    }
}