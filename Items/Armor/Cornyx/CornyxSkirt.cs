using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Cornyx {
    [AutoloadEquip(EquipType.Legs)]
    public class CornyxSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cornyx's Skirt");
            Tooltip.SetDefault("5% increased fire crit" +
                "\n5% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
            player.moveSpeed *= 1.05f;
        }
        public override bool DrawLegs(){
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.LavaBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}