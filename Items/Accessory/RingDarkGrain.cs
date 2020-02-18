using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingDarkGrain : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Darkwood Grain Ring");
            Tooltip.SetDefault("Increased reflexes");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.dash += 1;
            player.runAcceleration += 1;
            player.ignoreWater = true;
            player.buffImmune[BuffID.Slow] = true;
            player.maxFallSpeed += 10;
            player.fallStart = 0;
            player.jumpSpeedBoost += 3;
            player.noFallDmg = true;
            player.meleeSpeed += 0.20f;

            if (player.velocity.Y != 0) player.GetModPlayer<DrakSolzPlayer>().Rotate = true;
            player.GetModPlayer<DrakSolzPlayer>().Rotation += player.velocity.X * 0.025f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 50);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessory.RingCat>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}