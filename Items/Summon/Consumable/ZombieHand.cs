using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class ZombieHand : SoulItem {
        public ZombieHand() : base(100) { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Zombie Hand");
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.shootSpeed = 12f;
            item.width = 20;
            item.height = 20;
            item.maxStack = 5;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.useTime = 26;
            item.mana = 5;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.summon = true;
            item.damage = 10;
            item.knockBack = 5f;
            item.value = Item.buyPrice(0, 0, 5, 0);
            item.rare = 1;
            item.shoot = mod.ProjectileType<Projectiles.Minion.Consumable.ZombieHandProj>();
            item.autoReuse = true;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            if (fromPlayer != player.whoAmI) return;
            grabRange = (int)player.Distance(item.Center);
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Minion.Consumable.Zombie>()] + player.ownedProjectileCounts[item.shoot] < 5;
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
            recipe.AddIngredient(ItemID.ZombieArm);
            recipe.AddRecipe();
        }
    }
}