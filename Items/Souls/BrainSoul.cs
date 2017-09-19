﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class BrainSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Crimson Soul");
            Tooltip.SetDefault("Soul of the Brain of Cthulhu");
        }

        public BrainSoul() {
            Place = 3;
            Ticks = 50;
        }
    }
}