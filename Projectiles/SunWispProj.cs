using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class SunWispProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sun Wisp Fragment");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.AmberBolt);
            projectile.aiStyle = 29;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.alpha = 0;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }
        public override void AI() {
            if (projectile.timeLeft <= 30) {
                projectile.velocity *= 0.96f;
            }
            projectile.scale = 1.0f;
            projectile.rotation += 0.2f * projectile.direction;
            projectile.alpha = 0;

        }

        public override void Kill(int timeLeft) {
            Utils.PoofOfSmoke(projectile.Center);
            NPC.NewNPC((int) projectile.Center.X, (int) projectile.Center.Y, ModContent.NPCType<NPCs.Enemy.Endgame.Hallow.MiniSun>());
        }
    }
}