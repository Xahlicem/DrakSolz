using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class DukeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Drenched Soul");
            Tooltip.SetDefault("Soul of Duke Fishron");
        }

        public DukeSoul() {
            Place = 14;
            Ticks = 150;
        }
    }
}