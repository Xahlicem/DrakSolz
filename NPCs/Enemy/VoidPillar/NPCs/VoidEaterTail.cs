using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.VoidPillar.NPCs {
    public class VoidEaterTail : ModNPC {
        public override void SetDefaults() {
            npc.lifeMax = 1;
            npc.damage = 60;
            npc.defense = 10;
            npc.width = 44;
            npc.height = 46;
            npc.noTileCollide = true;
            npc.behindTiles = true;
            npc.friendly = false;
            npc.noGravity = true;
            npc.aiStyle = 6;
            npc.dontTakeDamage = false;
            npc.HitSound = SoundID.NPCHit2;
            npc.buffImmune[24] = true;
            npc.buffImmune[67] = true;
            npc.lavaImmune = true;
        }
        public override void OnHitPlayer(Player player, int damage, bool crit) {
            player.AddBuff(BuffID.Darkness, 300);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) {
            return false;
        }

        public override void AI() {
            if (!Main.npc[(int) npc.ai[1]].active) {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
        }
    }
}