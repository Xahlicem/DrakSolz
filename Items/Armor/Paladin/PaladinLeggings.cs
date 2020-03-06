using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Paladin {
    [AutoloadEquip(EquipType.Legs)]
    public class PaladinLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Paladin Leggings");
            Tooltip.SetDefault("Attire donned by Leeroy, a forgotten paladin" +
                "\n+10% miracle damage" +
                "\n-1 max minions" +
                "\n+15% movespeed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player) {
            if (player.maxMinions >= 1) {
                player.maxMinions -= 1;
            }
            player.minionDamage += 1.1f;
            player.moveSpeed *= 1.15f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 17);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}