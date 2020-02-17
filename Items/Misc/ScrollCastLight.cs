using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class ScrollCastLight : SoulItem {
        public ScrollCastLight() : base(1750) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cast Light");
            Tooltip.SetDefault("Creates light to follow you.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 1;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 5;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 3600; i++);
            player.AddBuff(BuffID.Shine, 3600);
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), + (360 * (int)(item.mana * player.manaCost)));
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Scroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}