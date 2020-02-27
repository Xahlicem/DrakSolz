using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class PyromancerEmblem : SoulItem {
        public PyromancerEmblem() : base(0) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pyromancer Emblem");
            Tooltip.SetDefault("15% increased fire damage");
        }

        public override void SetDefaults() {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.15f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessory.PyromancerEmblem>());
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.SetResult(ItemID.AvengerEmblem);
            recipe.AddRecipe();
        }
    }
}