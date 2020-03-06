using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Paladin {
    [AutoloadEquip(EquipType.Body)]
    public class PaladinArmor : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Paladin Armor");
            Tooltip.SetDefault("Attire donned by Leeroy, a forgotten paladin" +
                "\n+10% miracle damage" +
                "\n-1 max minions" +
                "\n+40 mana");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
            if(player.maxMinions >= 1){
            player.maxMinions -= 1;
            }
            player.minionDamage += 1.1f;
            player.statManaMax2 += 40;
        }
        public override void AddRecipes() {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
                recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}