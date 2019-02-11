using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Misc {
    public class ScrollHolyMajorHeal : SoulItem {
        public ScrollHolyMajorHeal() : base(50000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Major Heal");
            Tooltip.SetDefault("Restores a moderate amount of health.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.mana = 50;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 2; i++);
            player.statLife += 200;
            player.HealEffect(200);
            player.AddBuff(mod.BuffType<Buffs.ScrollMana>(), + (360 * (int)(item.mana * player.manaCost)));
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.ScrollHolyHeal>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}