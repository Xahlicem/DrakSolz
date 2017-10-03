using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Misc {
    public class ScrollHolyRegen : SoulItem {
        public ScrollHolyRegen() : base(5000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Regeneration");
            Tooltip.SetDefault("Restores health over a large period of time.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.MagicMirror);
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.mana = 40;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 60; i++);
            player.AddBuff(BuffID.RapidHealing, 2000);
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Misc.ScrollHoly>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}