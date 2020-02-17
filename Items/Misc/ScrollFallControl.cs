using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class ScrollFallControl : SoulItem {
        public ScrollFallControl() : base(3000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fall Control");
            Tooltip.SetDefault("Allows temporary slow fall.");
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
            for (int i = 0; i < 600; i++);
            player.AddBuff(BuffID.Featherfall, 600);
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