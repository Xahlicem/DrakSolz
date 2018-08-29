using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion {
    public class SwordSumProj : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 3;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            DisplayName.SetDefault("Summoned Sword");
        }

        public override void SetDefaults() {
            projectile.netImportant = true;
            projectile.CloneDefaults(388);
            aiType = 388;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
            projectile.timeLeft = projectile.timeLeft * 5;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale *= 0.7f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.velocity = oldVelocity;
            return false;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);

            if (player.dead) {
                modPlayer.DungeonSummon = false;
            }
            if (modPlayer.DungeonSummon) {
                projectile.timeLeft = 5;
            }
        }

    }
}