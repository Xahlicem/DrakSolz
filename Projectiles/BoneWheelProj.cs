using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class BoneWheelProj : ModProjectile {

        public override void SetDefaults() {
            projectile.width = 60;
            projectile.height = 60;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            projectile.timeLeft = 100;
            projectile.alpha = 100;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center;

            int i = player.FindBuffIndex(mod.BuffType<Buffs.BoneWheelMount>());
            if (i != -1) {
                projectile.timeLeft = 5;
            }
        }
    }
}