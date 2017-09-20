using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class LunaticSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Illusory Soul");
            Tooltip.SetDefault("Soul of the Lunatic Cultist");
        }

        public LunaticSoul() : base(13, 135, "RingDuskCrown") { }
    }
}