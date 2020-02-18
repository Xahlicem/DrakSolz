using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Void {
    [AutoloadEquip(EquipType.Legs)]
    public class VoidLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Void Leggings");
            Tooltip.SetDefault("Contains powers of the endless abyss." +
                "\n+20% increased movement speed" +
                "\n+10% increased thrown damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Red;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.1f;
            player.moveSpeed += 0.20f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.VoidFragment>(), 15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}