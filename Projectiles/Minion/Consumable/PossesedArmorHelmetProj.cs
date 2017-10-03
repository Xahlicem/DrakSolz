using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    class PossesedArmorHelmetProj : CMinionProj {
        public PossesedArmorHelmetProj() : base("PossesedArmor") { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Possesed Armor's Helmet");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            projectile.width = 20;
            projectile.height = 20;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 20;
            height = 18;
            return true;
        }
    }
}