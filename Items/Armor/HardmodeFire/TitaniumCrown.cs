using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanium Crown");
            Tooltip.SetDefault("0% increased fire damage" +
                "\n5% increased fire critical strike chance" +
                "\nincreases maximum mana by 60");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 60;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.09f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Become immune after striking an enemy");
            player.onHitDodge = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}