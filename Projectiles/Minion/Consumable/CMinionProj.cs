using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    abstract class CMinionProj : ModProjectile {
        public string MinionType { get; set; }
        public CMinionProj(string minionType) {
            MinionType = minionType;
        }

        public override string Texture { get { return "DrakSolz/Items/Summon/Consumable/" + Name.Substring(0, Name.Length - 4); } }

        public override void SetDefaults() {
            projectile.aiStyle = 2;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.minion = true;
        }

        public override void AI() {
            if (Math.Abs(projectile.velocity.X) > 0f) projectile.spriteDirection = projectile.direction;
        }

        public override void Kill(int timeLeft) {
            int pro = Projectile.NewProjectile(new Vector2(projectile.Center.X, projectile.Center.Y - 15), new Vector2(projectile.direction * 0.01f, 0), DrakSolz.instance.ProjectileType(MinionType), projectile.damage, projectile.knockBack, projectile.owner);
            Main.projectile[pro].spriteDirection = projectile.spriteDirection;
        }
    }
}