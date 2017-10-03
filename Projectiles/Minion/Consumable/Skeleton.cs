using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public class Skeleton : WalkingMinion {
        public Skeleton() : base("SkeletonSkull", 2.5f){}
        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 20;
            DisplayName.SetDefault("Skeleton");
        }

        public override bool? CanCutTiles() { return false; }

        public override void SetDefaults() {
            projectile.netImportant = true;
            projectile.aiStyle = 0;
            projectile.width = 40;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            ChangeState(State_Summon);
            projectile.frame = 19;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 20;
            height = 46;
            fallThrough = false;
            return true;
        }
    }
}