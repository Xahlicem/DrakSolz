using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class ArtoriasSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dark Soul");
            Tooltip.SetDefault("Soul of the Abysswalker");
        }

        public ArtoriasSoul() : base(16, 130) {
            Ring = mod.ItemType<Items.Accessory.RingTinyBeing>();
        }
    }
}