using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.SilverKnight {
    [AutoloadEquip(EquipType.Legs)]
    public class SilverKnightLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight Leggings");
            Tooltip.SetDefault("Apparel.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.20f;
            player.maxRunSpeed += 0.10f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}