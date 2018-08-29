using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class ParadigmScytheProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Paradigm Scythe");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 4.5f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 350f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.thrown = true;
			projectile.scale *= 0.8f;
			projectile.tileCollide = false;
		}

		public override void PostAI()
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
	}
}