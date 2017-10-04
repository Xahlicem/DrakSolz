using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Thorns {
    [AutoloadEquip(EquipType.Body)]
    public class ThornsArmor : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Armor of Thorns");
            Tooltip.SetDefault("Armor famed by Commander Kirk." +
                "\n+20% thorns" +
                "\n+50% increased thrown velocity");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 7;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
            player.thrownVelocity *= 1.5f;
            player.thorns += 0.20f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpikyBall, 250);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}