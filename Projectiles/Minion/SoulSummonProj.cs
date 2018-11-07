using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion {
    public class SoulSummonProj : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 8;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            DisplayName.SetDefault("Soul Staff");
        }

        public override void SetDefaults() {
            projectile.netImportant = true;
            projectile.CloneDefaults(317);
            aiType = 317;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
            projectile.knockBack = 0;
            projectile.timeLeft = projectile.timeLeft * 5;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);
            projectile.friendly = false;
            projectile.hostile = false;
            if (Main.time % 20 == 0) {
                projectile.friendly = true;
            }

            if (player.dead) {
                modPlayer.SoulSummon = false;
            }
            if (modPlayer.SoulSummon) {
                projectile.timeLeft = 5;
            }
        }

    }
}