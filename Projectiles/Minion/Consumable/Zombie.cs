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
    }
}