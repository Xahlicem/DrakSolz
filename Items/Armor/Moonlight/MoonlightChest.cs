using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Moonlight {
    [AutoloadEquip(EquipType.Body)]
    public class MoonlightChest : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Moonlight Chestplate");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
                "\n+15% increased magic damage and critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player) {
            player.magicCrit += 15;
            player.magicDamage *= 1.15f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.MoonButterflyHorn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}