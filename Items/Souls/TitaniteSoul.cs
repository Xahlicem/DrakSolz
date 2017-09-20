using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class TitaniteSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Reinforced Soul");
            Tooltip.SetDefault("Soul of the Titanite Demon");
        }

        public TitaniteSoul() : base(17, 150, "RingTinyBeing") { }
    }
}