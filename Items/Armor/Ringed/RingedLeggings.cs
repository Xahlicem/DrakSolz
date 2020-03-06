using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Ringed {
    [AutoloadEquip(EquipType.Legs)]
    public class RingedLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ringed Knight Leggings");
            Tooltip.SetDefault("Apparel.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Red;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player) {
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Banners.RingedKnightBanner>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}