using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class SkeletronSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bloodless Soul");
            Tooltip.SetDefault("Soul of Skeletron");
        }

        public SkeletronSoul() : base(5, 55, "RingBlades") { }
    }
}