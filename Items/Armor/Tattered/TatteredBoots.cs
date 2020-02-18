using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Tattered {
    [AutoloadEquip(EquipType.Legs)]
    public class TatteredBoots : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tattered Boots");
            Tooltip.SetDefault("Increases minion damage by 5%" +
                "\nIncreases your max number of minions");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player) {
            player.minionDamage *= 1.05f;
            player.maxMinions += 1;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.TatteredCloth, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}