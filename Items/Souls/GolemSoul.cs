using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class GolemSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hardened Soul");
            Tooltip.SetDefault("Soul of the Golem");
        }

        public GolemSoul() : base(12, 125) {
            Ring = mod.ItemType<Items.Accessory.RingTinyBeing>();
        }
    }
}