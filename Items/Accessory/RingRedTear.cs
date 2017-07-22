using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingRedTear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Red Tearstone Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+25% Damage when near death");
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
            if (player.statLife <= (player.statLifeMax * 0.2f)) {
                player.meleeDamage += 0.25f;
                player.magicDamage += 0.25f;
                player.thrownDamage += 0.25f;
                player.rangedDamage += 0.25f;
                player.minionDamage += 0.25f;
            } else {
                player.meleeDamage += 0f;
                player.magicDamage += 0f;
                player.thrownDamage += 0f;
                player.rangedDamage += 0f;
                player.minionDamage += 0f;
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