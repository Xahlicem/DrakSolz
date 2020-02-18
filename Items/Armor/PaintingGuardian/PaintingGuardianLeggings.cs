using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.PaintingGuardian {
    [AutoloadEquip(EquipType.Legs)]
    public class PaintingGuardianLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Painting Guardian Leggings");
            Tooltip.SetDefault("Increases minion damage by 5%");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player) {
            player.minionDamage *= 1.05f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}