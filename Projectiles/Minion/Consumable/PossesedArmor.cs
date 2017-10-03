using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public class PossesedArmor : WalkingMinion {
        public PossesedArmor() : base("PossesedArmorHelmet", 2f, 5, 14) { }
        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 20;
            DisplayName.SetDefault("Possesed Armor");
        }

        public override void AI() {
            if (Ticks % 4 == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 2 * (Main.rand.NextFloat() - 0.5f), 2 * (Main.rand.NextFloat() - 0.5f));
            base.AI();
        }

        public override void SummonDust() {
            for (int i = 0; i < 10; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 2 * (Main.rand.NextFloat() - 0.5f), 2 * (Main.rand.NextFloat() - 0.5f));
        }
    }
}