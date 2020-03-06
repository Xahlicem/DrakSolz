using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orichalcum Crown");
            Tooltip.SetDefault("14% increased fire damage" +
                "\n2% increased fire critical strike chance" +
                "\nincreases maximum mana by 40");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 25, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 40;
            player.GetModPlayer<MPlayer>().pyromancyDamage += 0.14f;
            player.GetModPlayer<MPlayer>().pyromancyCrit +=  2;
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
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}