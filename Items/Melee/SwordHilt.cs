using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class SwordHilt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sword Hilt");
            Tooltip.SetDefault("Why?");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.CopperPickaxe);
            item.tileBoost = -2;
            item.pick = 10;
            item.axe = 2;
            item.damage = 4;
            item.knockBack = 1f;
            item.useTime += 3;
            item.useAnimation += 3;
            item.GetGlobalItem<DSGlobalItem>().Restricted = true;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(0, 0);
        }
    }
}