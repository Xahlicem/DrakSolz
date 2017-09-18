using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    // This ModNPC serves as an example of a complete AI example.
    public class Abysswalker : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Abysswalker");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DD2OgreT2];
            //Main.npcFrameCount[npc.type] = 48; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.DD2OgreT2);
            npc.width = 40;
            npc.scale *= 2f;
            npc.height = 44;
            npc.aiStyle = 107;
            aiType = NPCID.DD2OgreT2;
            animationType = NPCID.DD2OgreT2;
            npc.frame = new Rectangle(0,0,118,64);
            npc.setFrameSize = true;
            npc.damage = 1;
            npc.defense = 50;
            npc.lifeMax = 1750;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 50000f;
            npc.knockBackResist = 0.5f;
            npc.buffImmune[BuffID.Confused] = true; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            // we would like this npc to spawn in the overworld.
            return SpawnCondition.Mummy.Chance * 0.5f;
        }
        public override void FindFrame(int frameHeight) {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.frame.Width = 118;
            npc.spriteDirection = npc.direction;
        }
        /*public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (!npc.HasValidTarget || Main.player[npc.target].Distance(enemy) > 400f) {
                npc.velocity = new Vector2(npc.direction * 10, y);
            } else if (!npc.HasValidTarget || Main.player[npc.target].Distance(enemy) > 240f) {
                npc.velocity = new Vector2(npc.direction * 8, y);
            } else if (!npc.HasValidTarget || Main.player[npc.target].Distance(enemy) > 120f) {
                npc.velocity = new Vector2(npc.direction * 6, y);
            } else if (!npc.HasValidTarget || Main.player[npc.target].Distance(enemy) > 36f) {
                npc.velocity = new Vector2(npc.direction * 4.5f, y);
            } else {

            }
    }*/
    }
}