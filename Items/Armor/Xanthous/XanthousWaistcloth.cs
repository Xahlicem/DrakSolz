using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip(EquipType.Legs)]
    public class XanthousWaistcloth : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Xanthous Waistcloth");
            Tooltip.SetDefault("Attire donned by Xanthous, the old monk." +
                "\n+5% fire damage" +
                "\n+20% movespeed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
            player.moveSpeed *= 1.20f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            recipe.AddIngredient(ItemID.LivingFireBlock, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}