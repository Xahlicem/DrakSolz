using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hallowed Headgear");
            Tooltip.SetDefault("+25% thrown damage" +
                "\n+15% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 5;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.25f;
            player.thrownCrit += 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("+50% chance to not consume thrown item" +
                "\n+40% thrown velocity");
            player.thrownCost50 = true;
            player.thrownVelocity *=1.4f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}