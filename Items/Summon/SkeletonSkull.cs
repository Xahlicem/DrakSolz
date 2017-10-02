using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon {
    class SkeletonSkull : SoulItem {
        public SkeletonSkull() : base(1000) { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Skeleton Skull");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.shootSpeed = 12f;
            item.width = 24;
            item.height = 26;
            item.maxStack = 5;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.useTime = 26;
            item.mana = 5;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.summon = true;
            item.damage = 20;
            item.knockBack = 5f;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 1;
            item.shoot = mod.ProjectileType<Projectiles.Minion.SkeletonProj>();
            item.autoReuse = true;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        public override void Update(ref float gravity, ref float maxFallSpeed) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            if (fromPlayer == -1) return;
            Player p = Main.player[fromPlayer];

            if (Collision.CanHitLine(item.position, item.width, item.height, p.position, p.width, p.height))
                item.velocity = (p.position - item.position) * 0.1f;
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Minion.SkeletonSummon>()] + player.ownedProjectileCounts[item.shoot] < 5;
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
        }
    }
}