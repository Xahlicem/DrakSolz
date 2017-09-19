using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class PlantSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Verdant Soul");
            Tooltip.SetDefault("Soul of Plantera");
        }

        public PlantSoul() {
            Place = 0;
            Ticks = 40;
        }
    }
}