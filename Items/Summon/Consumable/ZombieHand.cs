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
            ItemID.Sets.ItemNoGravity[item.type] = true;
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
            item.magic = true;
            item.crit = 50;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.summon = false;
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

        public override void Update(ref float gravity, ref float maxFallSpeed) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            if (fromPlayer == -1) return;
            Player p = Main.player[fromPlayer];
            Vector2 vel = (p.position - item.position);
            DrakSolz.AdjustMagnitude(ref vel, 10f);
            item.velocity = vel;
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