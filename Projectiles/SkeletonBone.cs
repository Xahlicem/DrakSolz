using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class SkeletonBone : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_21"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton's Bone");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Bone);
            projectile.aiStyle = 2;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }

        readonly int[] spawn = { NPCID.RustyArmoredBonesAxe, NPCID.RustyArmoredBonesFlail, NPCID.RustyArmoredBonesSword, NPCID.RustyArmoredBonesSwordNoArmor };

        public override void Kill(int timeLeft) {
            Utils.PoofOfSmoke(projectile.Center);
            if (Main.rand.NextFloat() <= 0.05f) NPC.NewNPC((int) projectile.Center.X, (int) projectile.Center.Y, NPCID.BoneLee);
            else NPC.NewNPC((int) projectile.Center.X, (int) projectile.Center.Y, Utils.SelectRandom(Main.rand, spawn));
        }
    }
}