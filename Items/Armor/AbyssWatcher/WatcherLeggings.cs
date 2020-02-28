using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.AbyssWatcher {
    [AutoloadEquip(EquipType.Legs)]
    public class WatcherLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Watcher's Leggings");
            Tooltip.SetDefault("10% increased critical strike chance" +
                "\n20% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyCrit += 10;
            player.meleeCrit += 10;
            player.magicCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
            player.moveSpeed *= 1.20f;
            player.maxRunSpeed *= 1.20f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 15);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}