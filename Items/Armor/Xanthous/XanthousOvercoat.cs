using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip(EquipType.Body)]
    public class XanthousOvercoat : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Xanthous Overcoat");
            Tooltip.SetDefault("Attire donned by Xanthous, the old monk." +
                "\n+5% fire damage" +
                "\n+5% fire critical chance" +
                "\n+40 life");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
            player.GetModPlayer<DrakSolzPlayer>().MiscHP += 40;
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