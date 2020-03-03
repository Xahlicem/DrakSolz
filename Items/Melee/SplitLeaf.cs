using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class SplitLeaf : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Splitleaf Greatsword");
            Tooltip.SetDefault("Sword wielded by Korvian Knights, brandishing four thin-edge blades in the left hand." +
                "\nPrimary attack deals melee damage." +
                "\nAlternate attack deals throwing damage.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BreakerBlade);
            item.damage = 110;
            item.useStyle = 5;
            item.useAnimation = 26;
            item.useTime = 30;
            item.shootSpeed = 5.4f;
            item.knockBack = 4.5f;
            item.width = 28;
            item.height = 28;
            item.scale = 1f;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<Projectiles.SplitLeafProj>();
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = true;
        }
        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override bool AltFunctionUse(Player player) {
            /*item.melee = false;
            item.thrown = true;*/
            return true;
        }

        public override bool UseItem(Player player) {
            if (player.altFunctionUse != 2) {
                item.noMelee = false;
                item.noUseGraphic = false;
                item.useStyle = 1;
                item.useAnimation = 4;
                item.useTime = 4;
                item.reuseDelay = 4;
            } else {
                item.noMelee = true;
                item.noUseGraphic = true;
                item.useStyle = 5;
                item.useAnimation = 24;
                item.useTime = 24;
                item.reuseDelay = 24;
            }
            return base.UseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.altFunctionUse != 2) {
                item.noMelee = false;
                item.noUseGraphic = false;
                item.useStyle = 1;
                item.useAnimation = 24;
                item.useTime = 8;
                item.reuseDelay = 24;
                return false;
            } else {
                item.noMelee = true;
                item.noUseGraphic = true;
                item.useStyle = 5;
                item.useAnimation = 24;
                item.useTime = 24;
                item.reuseDelay = 24;
                return true;
            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.VoidFragment>(), 15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}