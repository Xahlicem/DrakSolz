using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Cornyx {
    [AutoloadEquip(EquipType.Legs)]
    public class CornyxSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cornyx's Skirt");
            Tooltip.SetDefault("5% increased fire damage and critical strike chance" +
                "\n5% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
            player.moveSpeed *= 1.15f;
            player.maxRunSpeed *= 1.15f;
        
        }
        public override bool DrawLegs(){
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 15);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}