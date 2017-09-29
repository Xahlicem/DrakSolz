using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingFavor : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Favor and Protection");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+50 Max Life" +
                "\n+50 Max Mana" +
                "\n+30% Max Move Speed" +
                "\n+15% Melee Speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 1;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
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
            recipe.AddIngredient(mod.ItemType<Items.Accessory.RingCloranthy>());
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}