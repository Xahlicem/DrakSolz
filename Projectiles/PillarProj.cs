using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class PillarProj : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pillar Orb"); //The English name of the projectile
        }

        public override void SetDefaults() {
            projectile.width = 8; //The width of projectile hitbox
            projectile.height = 8; //The height of projectile hitbox
            projectile.aiStyle = 0; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = false; //Can the projectile deal damage to enemies?
            projectile.hostile = true; //Can the projectile deal damage to the player?
            projectile.penetrate = 1; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 2400; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            //projectile.light = 0.5f;            //How much light emit around the projectile
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true; //Can the projectile collide with tiles?
            projectile.scale *= 1;
            //aiType = ProjectileID.Bullet; //Act exactly like default Bullet
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 5;
            height = 5;
            return true;
        }
        public override void AI() {

            projectile.ai[0]++;
            projectile.ai[0]++;
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, 0, 0, 0, Color.Black);
            Main.dust[dust].velocity *= 1f + Main.rand.NextFloat();
            Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
            Main.dust[dust].noGravity = true;
        }
    }
}