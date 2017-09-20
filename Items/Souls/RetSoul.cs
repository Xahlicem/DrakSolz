using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class RetSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Malevolent Soul");
            Tooltip.SetDefault("Soul of Retinazer");
        }

        public RetSoul() : base(8, 85, "RingBlueTear") { }
    }
}