using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DragonSlayer {
    [AutoloadEquip(EquipType.Body)]
    public class DragonSlayerChest : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Dragonslayer Armor");
            Tooltip.SetDefault("Armor fashioned by Oreostein." +
                "\n+10% increased thrown and melee crit" +
                "\n+10% increased thrown damage" +
                "\n+15% increased melee speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 8;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
            player.meleeCrit += 10;
            player.thrownCrit += 10;
            player.thrownDamage *= 1.10f;
            player.meleeSpeed *= 1.15f;
        }
        /*public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 30);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}