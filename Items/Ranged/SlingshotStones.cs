using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged {
    public class SlingshotStones : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Small Stones");
            Tooltip.SetDefault("Large metal arrows used to penetrate the flesh of dragons.");
        }

        public override void SetDefaults() {
            item.damage = 6;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true; //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 2f;
            item.value = 0;
            item.rare = 0;
            item.shoot = ModContent.ProjectileType<Projectiles.SlingshotStonesProj>(); //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 8f; //The speed of the projectile
            item.ammo = (ModContent.ItemType<Items.Ranged.SlingshotStones>()); //The ammo class this ammo belongs to.
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }

    public class SlingshotMod : GlobalItem {
        public override void SetDefaults(Item item) {
            if (item.type == ItemID.SpikyBall) item.ammo = ModContent.ItemType<Items.Ranged.SlingshotStones>();
        }
    }
}