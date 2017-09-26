using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class ThiefEmblem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Thief's Emblem");
            Tooltip.SetDefault("15% increased throwing damage");
        }

        public override void SetDefaults() {
            item.width = 20;
            item.height = 20;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.thrownDamage += 0.15f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessory.ThiefEmblem>());        
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.SetResult(ItemID.AvengerEmblem);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}