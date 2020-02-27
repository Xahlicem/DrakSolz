using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Palladium Crown");
            Tooltip.SetDefault("8% increased fire damage" +
                "\n4% increased fire critical strike chance" +
                "\nincreases maximum mana by 20");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.CobaltMask);
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = 18;
            item.height = 18;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 20;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.08f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 4;
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