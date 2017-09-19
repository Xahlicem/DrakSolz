using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class SpazSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Malicious Soul");
            Tooltip.SetDefault("Soul of Spazmatism");
        }

        public SpazSoul() : base(9, 85) { }
    }
}