﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class ScrollRemedy : SoulItem {
        public ScrollRemedy() : base(2750) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Remedy");
            Tooltip.SetDefault("Cures one of all poisons, toxins, and bleeding effects.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 1;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 10;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 300; i++);
            player.AddBuff(mod.BuffType<Buffs.RemedyBuff>(), 300);
            player.AddBuff(mod.BuffType<Buffs.ScrollMana>(), + (360 * (int)(item.mana * player.manaCost)));
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Scroll>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}