using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orichalcum Headgear");
            Tooltip.SetDefault("7% increased ranged damage" +
                "\n7% increased ranged critical strike chance" +
                "\n7% increased movement");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 25);
            item.rare = 4;
            item.defense = 11;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.07f;
            player.thrownCrit += 7;
            player.moveSpeed *= 1.07f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Flower petals will fall on your target for extra damage");
            player.onHitPetal = true;
        }
        
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}