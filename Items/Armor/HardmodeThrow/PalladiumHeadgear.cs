using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Palladium Headgear");
            Tooltip.SetDefault("9% increased ranged damage" +
                "\n9% increased ranged critical strike chance");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.CobaltMask);
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = 18;
            item.height = 18;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.09f;
            player.thrownCrit += 9;
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
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}