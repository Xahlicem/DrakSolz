using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Armor {
    [AutoloadEquip(EquipType.Legs)]
    public class ChannelerSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Channeler's Skirt");
            Tooltip.SetDefault("Description!" +
                "\n10% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.10f;
            player.maxRunSpeed += 0.10f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}