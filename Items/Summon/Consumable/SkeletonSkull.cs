using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class SkeletonSkull : SoulItem {
        public SkeletonSkull() : base(1000) { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Skeleton Skull");
        }

        public override void SetDefaults() {
            item.CloneDefaults(mod.ItemType<Items.Summon.Consumable.ZombieHand>());
            item.width = 24;
            item.height = 26;
            item.mana = 10;
            item.damage = 20;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType<Projectiles.Minion.Consumable.SkeletonSkullProj>();
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            if (fromPlayer != player.whoAmI) return;
            grabRange = (int) player.Distance(item.Center);
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Minion.Consumable.Skeleton>()] + player.ownedProjectileCounts[item.shoot] < 5;
        }

        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.altFunctionUse == 2) {
                speedY = 10;
                speedX *= 0.001f;
            }
            return true;
        }

        public override void AddRecipes() {
            SoulRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddRecipe();
        }
    }
}