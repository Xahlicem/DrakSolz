﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class PyroScrollIron : SoulItem {
        public PyroScrollIron() : base(2000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Iron Flesh");
            Tooltip.SetDefault("Increases defense at the cost of speed.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.MagicMirror);
            item.useStyle = 1;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 20;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 1300; i++);
            player.AddBuff(BuffID.Ironskin, 1300);
            player.AddBuff(BuffID.ObsidianSkin, 1300);
            player.AddBuff(BuffID.Slow, 1300);
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.PyroScroll>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}