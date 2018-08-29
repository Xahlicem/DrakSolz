using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class DervishWind : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_21"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dervish Wind");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Bone);
            projectile.aiStyle = 2;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }
        public override void Kill(int timeLeft) {
            Utils.PoofOfSmoke(projectile.Center);
            NPC.NewNPC((int) projectile.Center.X, (int) projectile.Center.Y, mod.NPCType<NPCs.Enemy.Endgame.Desert.Dervish>());
        }
    }
}