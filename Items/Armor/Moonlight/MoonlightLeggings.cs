using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Moonlight {
    [AutoloadEquip(EquipType.Legs)]
    public class MoonlightLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Leggings");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
                "\n+Water Walking" +
                "\n+11% increased magic critical strike chance" +
                "\n10% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.magicCrit += 11;
            player.moveSpeed += 0.10f;
            player.waterWalk = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.MoonButterflyHorn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}