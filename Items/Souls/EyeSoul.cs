using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class EyeSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Peering Soul");
            Tooltip.SetDefault("Soul of the Eye of Cthulhu");
        }

        public EyeSoul() : base(1, 45) {
            Ring = mod.ItemType<Items.Accessory.RingTinyBeing>();
        }
    }
}