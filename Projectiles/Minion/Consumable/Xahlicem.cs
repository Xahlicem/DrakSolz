using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public class Xahlicem : WalkingMinion {
        public Xahlicem() : base("XahlicemEye", 2f, 5, 13) { }
        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 19;
            DisplayName.SetDefault("Xahlicem");
        }

        public override void AI() {
            if (Ticks % 60 == 0) {
                int proj = Projectile.NewProjectile(new Vector2(projectile.Center.X + (40 * projectile.direction), projectile.Center.Y), new Vector2(10 * projectile.direction, 0f), ProjectileID.CrystalPulse, projectile.damage, 4, projectile.owner);
                Main.projectile[proj].magic = false;
                Main.projectile[proj].minion = true;
            }
            if (Ticks % 4 == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 2 * (Main.rand.NextFloat() - 0.5f), 2 * (Main.rand.NextFloat() - 0.5f));
            base.AI();
        }

        public override void SummonDust() {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 2 * (Main.rand.NextFloat() - 0.5f), 2 * (Main.rand.NextFloat() - 0.5f));
        }
    }
}