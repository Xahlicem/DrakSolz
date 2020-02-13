using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class PyroScrollPower : SoulItem {
        public PyroScrollPower() : base(50000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Power Within");
            Tooltip.SetDefault("Consume life to increase damage for 60 seconds.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 1;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 2;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 20;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 3600; i++);
            player.AddBuff(ModContent.BuffType<Buffs.PowerBuff>(), 3600);
            player.AddBuff(BuffID.Warmth, 3600);
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.PyroScroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}