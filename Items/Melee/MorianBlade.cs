using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
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
            item.value = Item.buyPrice(0, 15, 0, 0);
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(0, 0);
        }

        public override bool UseItem(Player player) {
            item.damage = 30 + (int)((player.statLifeMax2 - player.statLife) * 0.1f);
            return base.UseItem(player);
        }
    }
}