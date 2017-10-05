using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumThrow : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Palladium Head Piece");
            Tooltip.SetDefault("+22% thrown damage" +
                "\n+12% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 1, 50);
            item.rare = 4;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.22f;
            player.thrownCrit += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Greatly increases life regeneration after striking an enemy");
            player.onHitRegen = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}