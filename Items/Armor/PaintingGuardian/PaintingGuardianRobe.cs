using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.PaintingGuardian {
    [AutoloadEquip(EquipType.Body)]
    public class PaintingGuardianRobe : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Painting Guardian Robe");
            Tooltip.SetDefault("Increases movement speed by 5%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed *= 1.05f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}