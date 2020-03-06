using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.FireKeeper {
    [AutoloadEquip(EquipType.Body)]
    public class FireKeeperShirt : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fire Keeper's Shirt");
            Tooltip.SetDefault("Increases fire damage by 15%");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.15f;
        }
        public override void DrawHands(ref bool drawHands, ref bool drawArms){
            drawHands = true;
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