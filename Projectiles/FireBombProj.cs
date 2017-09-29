using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class FireBombProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Bomb");
        }

        public override void SetDefaults() {
            projectile.scale = 0.75f;
            projectile.tileCollide = true;
            projectile.width = 38;
            projectile.height = 40;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
        }

        public override void Kill(int timeLeft) {
            Main.PlaySound(SoundID.Item15, projectile.position);

            int proj = Projectile.NewProjectile(projectile.Center, projectile.velocity, ProjectileID.GrenadeI, projectile.damage, 0.25f, projectile.owner);
            Main.projectile[proj].thrown = true;
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 1;
        }
    }
}