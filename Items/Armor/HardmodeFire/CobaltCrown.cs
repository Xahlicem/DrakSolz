using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class CobaltCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cobalt Crown");
            Tooltip.SetDefault("10% increased fire damage" +
                "\n6% increased fire critical strike chance" +
                "\nincreases maximum mana by 30");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.CobaltMask);
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = 18;
            item.height = 18;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 30;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.10f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-10% mana cost" +
                "\n5% increased fire damage");
			player.manaCost *= 0.90f;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
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