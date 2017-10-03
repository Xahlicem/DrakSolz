using System;
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
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 20;
            height = 46;
            fallThrough = false;
            return true;
        }
    }
}