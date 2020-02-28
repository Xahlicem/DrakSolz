using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.AbyssWatcher {
    [AutoloadEquip(EquipType.Body)]
    public class WatcherChest : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Watcher's Armor");
            Tooltip.SetDefault("Increases melee speed by 20%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player) {
			player.meleeSpeed *= 0.80f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 18);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}