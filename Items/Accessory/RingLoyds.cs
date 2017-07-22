using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingLoyds : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Loyd's Sword Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+20% Damage when at Max Life");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.statLife >= (player.statLifeMax * 1)) {
                player.meleeDamage += 0.20f;
                player.magicDamage += 0.20f;
                player.thrownDamage += 0.20f;
                player.rangedDamage += 0.20f;
                player.minionDamage += 0.20f;
            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 500);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}