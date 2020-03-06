using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Havels {
    [AutoloadEquip(EquipType.Body)]
    public class HavelsArmor : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Habel's Armor");
            Tooltip.SetDefault("Apparel worn by Habel the Rock.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 35;
        }

        public override void UpdateEquip(Player player) {
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}