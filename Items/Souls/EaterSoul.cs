using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class EaterSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Corrupt Soul");
            Tooltip.SetDefault("Soul of the Eater of Worlds");
        }

        public EaterSoul() {
            Place = 2;
            Ticks = 50;
        }
    }
}