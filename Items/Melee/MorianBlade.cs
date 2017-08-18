using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Melee {
    public class MorianBlade : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Morian Blade");
            Tooltip.SetDefault("Thrives off of its wielder's mortality.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BreakerBlade);
            item.damage = 40;
            item.knockBack = 6f;
            item.useTime = 2;
            item.useAnimation = 25;
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(0, 0);
        }

        public override bool UseItem(Player player) {
            item.damage = 30 + (int)((player.statLifeMax - player.statLife) * 0.1f);
            return base.UseItem(player);
        }
    }
}