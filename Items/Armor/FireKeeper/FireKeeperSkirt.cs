using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.FireKeeper {
    [AutoloadEquip(EquipType.Legs)]
    public class FireKeeperSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Keeper's Skirt");
            Tooltip.SetDefault("5% increased fire critical strike chance" +
                "\n20% increased movement speed" +
                "\nfirewalking");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
            player.moveSpeed *= 1.20f;
            player.maxRunSpeed *= 1.10f;
            player.fireWalk = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddRecipe();
        }
    }
}