using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Tattered {
    [AutoloadEquip(EquipType.Body)]
    public class TatteredTunic : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Tattered Tunic");
            Tooltip.SetDefault("Increases minion damage by 10%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player) {
            player.minionDamage *= 1.10f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.TatteredCloth, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}