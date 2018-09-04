using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles
{
	public class HighTemplarHammerproj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("High Templar Hammer");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
			aiType = ProjectileID.PaladinsHammerFriendly;
            projectile.melee = false;
            projectile.thrown = true;
			projectile.scale *= 0.7f;
			projectile.width = 40;
			projectile.height = 50;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.PaladinsHammerFriendly;
			return true;
		}
	}
}