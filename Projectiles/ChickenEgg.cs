using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class ChickenEgg : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_318"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chicken Egg");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.RottenEgg);
            projectile.aiStyle = 2;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }

        public override void Kill(int timeLeft) {
            Utils.PoofOfSmoke(projectile.Center);
            NPC.NewNPC((int) projectile.Center.X, (int) projectile.Center.Y, ModContent.NPCType<NPCs.Enemy.PreHardMode.EvilChicken>());
        }
    }
}