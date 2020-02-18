using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class SkeletonSkull : CMinionItem {
        public SkeletonSkull() : base(1000, "Skeleton") { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Skeleton Skull");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.width = 24;
            item.height = 26;
            item.mana = 10;
            item.damage = 20;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = ItemRarityID.Orange;
            item.shoot = ModContent.ProjectileType<Projectiles.Minion.Consumable.SkeletonSkullProj>();
        }

        public override void AddRecipes() {
            SoulRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddRecipe();
        }
    }
}