using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace XahlicemMod.Items.Accessory {
    public class SkullLantern : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skull Lantern");
            Tooltip.SetDefault("Gives off light.");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.maxRunSpeed += 0.30f;
            player.AddBuff(BuffID.Shine, 2);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 1500);
            recipe.AddIngredient(mod.ItemType("HomewardBone"), 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}