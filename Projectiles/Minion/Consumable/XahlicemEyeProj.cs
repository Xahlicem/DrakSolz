using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    class XahlicemEyeProj : CMinionProj {
        public XahlicemEyeProj() : base("Xahlicem") { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Eye of Xahlicem");
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