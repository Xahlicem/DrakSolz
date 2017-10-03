using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public class Zombie : WalkingMinion {
        public Zombie() : base("ZombieHand", 1.5f, 10, 3) { }
        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 9;
            DisplayName.SetDefault("Zombie");
        }

        public override void SummonDust() {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 46), projectile.width, 10, DustID.Dirt, 2 * (Main.rand.NextFloat() - 0.5f), 1 * (Main.rand.NextFloat() - 1.5f));
        }
    }
}