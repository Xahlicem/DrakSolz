using System;
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
    }
}