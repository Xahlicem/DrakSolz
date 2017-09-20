using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class DukeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Drenched Soul");
            Tooltip.SetDefault("Soul of Duke Fishron");
        }

        public DukeSoul() : base(14, 150) {
            Ring = mod.ItemType<Items.Accessory.RingTinyBeing>();
        }
    }
}