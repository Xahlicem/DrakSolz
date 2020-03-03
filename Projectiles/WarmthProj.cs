using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles {
    public class WarmthProj : ModProjectile {
        public override string Texture { get { return "Terraria/Projectile_15"; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Warmth"); //The English name of the projectile
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; //The recording mode
        }

        public override void SetDefaults() {
            projectile.width = 15; //The width of projectile hitbox
            projectile.height = 15; //The height of projectile hitbox
            projectile.aiStyle = 29; //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = false; //Can the projectile deal damage to enemies?
            projectile.hostile = true; //Can the projectile deal damage to the player?
            projectile.damage = 0;
            projectile.penetrate = -1; //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 3600; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 255; //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            //projectile.light = 1.0f;            //How much light emit around the projectile
            projectile.ignoreWater = true; //Does the projectile's speed be influenced by water?
            projectile.tileCollide = false; //Can the projectile collide with tiles?
            projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
            projectile.scale *= 1.5f;
            aiType = ProjectileID.AmberBolt; //Act exactly like default Bullet
        }
        public override void AI() {
            float distance = 150f;
            Player p;

            for (int k = 0; k < 200; k++) {
                p = Main.player[k];
                if (p.active) {
                    if (projectile.WithinRange(p.Center, distance)) {
                        p.AddBuff(ModContent.BuffType<Buffs.WarmthBuff>(), 30);
                        p.AddBuff(BuffID.Warmth, 30);
                    }
                }
            }
        }
    }
}