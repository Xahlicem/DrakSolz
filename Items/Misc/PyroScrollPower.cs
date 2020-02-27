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
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Green;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 20;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 3600; i++);
            player.AddBuff(ModContent.BuffType<Buffs.PowerBuff>(), 3600);
            player.AddBuff(BuffID.OnFire, 3600);
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), + (360 * (int)(item.mana * player.manaCost)));
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