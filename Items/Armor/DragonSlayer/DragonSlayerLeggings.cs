using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DragonSlayer {
    [AutoloadEquip(EquipType.Legs)]
    public class DragonSlayerLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dragonslayer Leggings");
            Tooltip.SetDefault("Armor fashioned by Oreostein." +
                "\n+15% movespeed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 10, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.15f;
        }
        /*public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}