using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.SilverKnight {
    [AutoloadEquip(EquipType.Body)]
    public class SilverKnightArmor : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Silver Knight Armor");
            Tooltip.SetDefault("Apparel."+
                "\n20% increased melee speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player) {
            player.meleeSpeed *= 1.2f;
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