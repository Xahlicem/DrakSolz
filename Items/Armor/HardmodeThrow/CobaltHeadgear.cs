using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class CobaltHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cobalt Headgear");
            Tooltip.SetDefault("10% increased ranged damage" +
                "\n6% increased ranged critical strike chance");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.CobaltMask);
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = 18;
            item.height = 18;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.1f;
            player.thrownCrit += 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("33% chance to not consume thrown item" +
                "\n20% increased throwing velocity");
            player.thrownCost33 = true;
            player.thrownVelocity *=1.2f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}