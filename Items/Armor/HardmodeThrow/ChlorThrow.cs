using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class ChlorThrow : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chlorophyte Head Piece");
            Tooltip.SetDefault("+30% thrown damage" +
                "\n+15% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.rare = 7;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.3f;
            player.thrownCrit += 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("+50% chance to not consume thrown item" +
                "\n+50% thrown velocity");
            player.thrownCost50 = true;
            player.thrownVelocity *=1.5f;
            player.AddBuff(BuffID.LeafCrystal, 2);
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}