using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion {
    public class FlameSum : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 8;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            DisplayName.SetDefault("Flamewreath");
        }

        public override void SetDefaults() {
            projectile.netImportant = true;
            projectile.CloneDefaults(317);
            aiType = 317;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
            projectile.timeLeft = projectile.timeLeft * 5;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.velocity = oldVelocity;
            return false;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();

            if (player.dead) {
                modPlayer.FireSummon = false;
            }
            if (modPlayer.FireSummon) {
                projectile.timeLeft = 5;
            }
        }

    }
}