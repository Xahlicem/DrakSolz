using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Melee {
    public class SwordHilt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sword Hilt");
            Tooltip.SetDefault("Why?");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.CopperPickaxe);
            item.tileBoost = -2;
            item.pick = 5;
            item.axe = 1;
            item.damage = 2;
            item.knockBack = 0.5f;
            item.useTime += 8;
            item.useAnimation += 8;
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(0, 0);
        }
    }
}