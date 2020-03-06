using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Father {
    [AutoloadEquip(EquipType.Body)]
    public class GiantArmor : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Giant's Armor");
            Tooltip.SetDefault("Become Unstoppable!");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 40;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 40);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 40);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}