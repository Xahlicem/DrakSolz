using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.VoidPillar.NPCs {

    public class VoidEaterHead : ModNPC {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Void Eater");
        }

        bool TailSpawned;

        public static int ShootRate = 20;
        const int ShootDamage = 58;
        const float ShootKN = 1.0f;
        const int ShootType = 297;
        const float ShootSpeed = 10;
        const int ShootCount = 5;
        const int spread = 2;
        const float spreadMult = 0.045f;

        const int ShootSound = 62;
        const int ShootSoundStyle = 1;

        int TimeToShoot = ShootRate;
        public override void SetDefaults() {
            npc.lifeMax = 6000;
            npc.damage = 150;
            npc.defense = 10;
            npc.knockBackResist = 0f;
            npc.width = 46;
            npc.height = 46;
            npc.aiStyle = 6;
            npc.npcSlots = 1f;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.friendly = false;
            npc.dontTakeDamage = false;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[24] = true;
            npc.buffImmune[67] = true;
            npc.lavaImmune = true;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.VoidEaterBanner>();
        }
		public override void OnHitPlayer(Player player, int damage, bool crit) {
            player.AddBuff(BuffID.Darkness, 300);
        }

        public override void AI() {
            npc.position += npc.velocity * (2 - 1);

            if (!TailSpawned) {
                int Previous = npc.whoAmI;
                for (int num36 = 0; num36 < 10; num36++) {
                    int lol = 0;
                    if (num36 >= 0 && num36 < 9) {
                        lol = NPC.NewNPC((int) npc.position.X + (npc.width / 2), (int) npc.position.Y + (npc.width / 2), mod.NPCType("VoidEaterBody"), npc.whoAmI);
                    } else {
                        lol = NPC.NewNPC((int) npc.position.X + (npc.width / 2), (int) npc.position.Y + (npc.width / 2), mod.NPCType("VoidEaterTail"), npc.whoAmI);
                    }
                    Main.npc[lol].realLife = npc.whoAmI;
                    Main.npc[lol].ai[2] = npc.whoAmI;
                    Main.npc[lol].ai[1] = Previous;
                    Main.npc[Previous].ai[0] = lol;
                    //NetMessage.SendData(23, -1, -1, "", lol, 0f, 0f, 0f, 0);
                    Previous = lol;
                }
                TailSpawned = true;
            }

            if ((int)(Main.time % 15) == 0) {
                Vector2 vector = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float birdRotation = (float) Math.Atan2(vector.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                npc.velocity.X = (float)(Math.Cos(birdRotation) * 4) * -1;
                npc.velocity.Y = (float)(Math.Sin(birdRotation) * 4) * -1;
                npc.netUpdate = true;
            }
        }

        public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                if (VoidPillarHandler.ShieldStrength > 0) {
                    NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("VoidPillar"))];
                    Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("PillarLaser"), 1, 1f);
                }
            }
        }
    }
}