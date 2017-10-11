using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanium Headgear");
            Tooltip.SetDefault("+27% thrown damage" +
                "\n+13% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 4;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.27f;
            player.thrownCrit += 13;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Briefly become invulnerable after striking an enemy");
            player.onHitDodge = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}