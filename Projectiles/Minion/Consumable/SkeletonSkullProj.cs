using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    class SkeletonSkullProj : CMinionProj {
        public SkeletonSkullProj() : base("Skeleton") { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton's Skull");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            projectile.width = 24;
            projectile.height = 26;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 20;
            height = 21;
            return true;
        }
    }
}