using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Misc {
    public class ScrollHolyHeal : SoulItem {
        public ScrollHolyHeal() : base(15000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Heal");
            Tooltip.SetDefault("Restores a moderate amount of health.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 4;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = ItemRarityID.Green;
            item.consumable = false;
            item.mana = 30;
        }

        public override bool UseItem(Player player) {
            int index = player.FindBuffIndex(ModContent.BuffType<Buffs.Hollow>());
            player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(10800);
            for (int i = 0; i < 2; i++);
            player.statLife += 90;
            player.HealEffect(90);
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), + (360 * (int)(item.mana * player.manaCost)));
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.ScrollHolyMinorHeal>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}