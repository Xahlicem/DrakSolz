using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Misc {
    public class ScrollHolyRegen : SoulItem {
        public ScrollHolyRegen() : base(25000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Regeneration");
            Tooltip.SetDefault("Restores health over a large period of time.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.mana = 40;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 60; i++);
            player.AddBuff(BuffID.RapidHealing, 2000);
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), + (360 * (int)(item.mana * player.manaCost)));
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.ScrollHoly>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}