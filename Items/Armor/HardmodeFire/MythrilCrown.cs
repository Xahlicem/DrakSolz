using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class MythrilCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mythril Crown");
            Tooltip.SetDefault("6% increased fire damage" +
                "\n7% increased fire critical strike chance" +
                "\nincreases maximum mana by 50");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 25, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 50;
            player.GetModPlayer<MPlayer>().pyromancyDamage += 0.06f;
            player.GetModPlayer<MPlayer>().pyromancyCrit +=  7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-14% mana cost" +
                "\n5% increased fire damage");
			player.manaCost *= 0.86f;
            player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}