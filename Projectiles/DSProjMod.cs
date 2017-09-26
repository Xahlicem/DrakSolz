using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class DSProjMod : GlobalProjectile {
        public override void SetDefaults(Projectile projectile) {
            if (projectile.aiStyle == 99 || projectile.aiStyle == 3 ||
                projectile.type == ProjectileID.VampireKnife || projectile.type == ProjectileID.FlyingKnife ||
                projectile.type == ProjectileID.ShadowFlameKnife || projectile.type == ProjectileID.Daybreak ||
                projectile.type == ProjectileID.TerrarianBeam) {
                projectile.melee = false;
                projectile.thrown = true;
            }
        }
    }
}