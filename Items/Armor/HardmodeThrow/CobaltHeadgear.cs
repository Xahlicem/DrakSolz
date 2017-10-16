using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class CobaltHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cobalt Headgear");
            Tooltip.SetDefault("+20% thrown damage" +
                "\n+12% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 1, 50);
            item.rare = 4;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.2f;
            player.thrownCrit += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("+50% chance to not consume thrown item" +
                "\n+10% thrown velocity");
            player.thrownCost50 = true;
            player.thrownVelocity *=1.1f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}