using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public class Skeleton : WalkingMinion {
        public Skeleton() : base("SkeletonSkull", 2.5f, 5, 14) { }
        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 20;
            DisplayName.SetDefault("Skeleton");
        }

        public override void SummonDust() {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 46), projectile.width, 10, DustID.Dirt, 2 * (Main.rand.NextFloat() - 0.5f), 1 * (Main.rand.NextFloat() - 1.5f));
        }
    }
}