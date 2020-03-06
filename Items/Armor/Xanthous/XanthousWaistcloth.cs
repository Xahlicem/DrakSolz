using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip(EquipType.Legs)]
    public class XanthousWaistcloth : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Xanthous Waistcloth");
            Tooltip.SetDefault("Attire donned by Xanthous, the old monk." +
                "\n+6% fire damage" +
                "\n+20% movespeed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
            player.GetModPlayer<MPlayer>().pyromancyDamage += 0.06f;
            player.moveSpeed *= 1.20f;
        }
        public override void AddRecipes() {
            if (NPC.downedPlantBoss) {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 16);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}