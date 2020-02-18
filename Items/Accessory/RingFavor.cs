using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingFavor : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Favor and Protection");
            Tooltip.SetDefault("Increases maximum life by 50" +
                "\nIncreases maximum mana by 50" +
                "\n30% increased maximum movement speed" +
                "\n+15% increased melee speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statManaMax2 += 50;
            player.statLifeMax2 += 50;
            player.maxRunSpeed += 0.30f;
            player.meleeSpeed += 0.15f;
            player.moveSpeed += 0.15f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessory.RingCloranthy>());
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}