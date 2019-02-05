using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class CrystalSoulMassProj : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 3;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            DisplayName.SetDefault("Crystal Soul Mass");
        }

        public override void SetDefaults() {
            projectile.netImportant = true;
            projectile.CloneDefaults(388);
            aiType = 388;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0.3f;
            projectile.penetrate = 1;
            projectile.timeLeft = projectile.timeLeft * 5;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale *= 1.5f;
            projectile.light = 0.4f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.velocity = oldVelocity;
            return false;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);

            if (player.dead) {
                modPlayer.SoulMassSum = false;
            }
            if (modPlayer.SoulMassSum) {
                projectile.timeLeft = 5;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.BlueCrystalShard);
            Main.dust[dust].velocity *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
            }
        }
    }
}