using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    class ZombieHandProj : CMinionProj {
        public ZombieHandProj() : base("Zombie") { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Zombie's Hand");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            projectile.width = 20;
            projectile.height = 20;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 18;
            height = 16;
            return true;
        }
    }
}