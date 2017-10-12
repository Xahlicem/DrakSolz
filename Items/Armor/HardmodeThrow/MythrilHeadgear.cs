using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class MythrilHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mythril Headgear");
            Tooltip.SetDefault("+20% thrown damage" +
                "\n+12% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 25);
            item.rare = 4;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.2f;
            player.thrownCrit += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("+50% chance to not consume thrown item" +
                "\n+20% thrown velocity");
            player.thrownCost50 = true;
            player.thrownVelocity *=1.2f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}