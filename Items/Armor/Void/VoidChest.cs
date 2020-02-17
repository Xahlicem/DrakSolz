using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Void {
    [AutoloadEquip(EquipType.Body)]
    public class VoidChest : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Void Chest");
            Tooltip.SetDefault("Contains powers of the endless abyss." +
                "\n+25% increased thrown damage" +
                "\n+50% increased thrown velocity");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 10;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.25f;
            player.thrownVelocity *= 1.5f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.VoidFragment>(), 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}