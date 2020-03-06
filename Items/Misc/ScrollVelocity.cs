using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class ScrollVelocity : SoulItem {
        public ScrollVelocity() : base(2250) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Velocity");
            Tooltip.SetDefault("Increased movement speed.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 90, 0);
            item.rare = ItemRarityID.Green;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 10;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 3600; i++);
            player.AddBuff(ModContent.BuffType<Buffs.VelocityBuff>(), 3600);
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), +(360 * (int) (item.mana * player.manaCost)));
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