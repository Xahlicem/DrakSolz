using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    // This ModNPC serves as an example of a complete AI example.
    public class ThePursuer : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Pursuer");
            Main.npcFrameCount[npc.type] = 4; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults() {
            npc.width = 44;
            npc.scale *= 1.1f;
            npc.height = 145;
            npc.aiStyle = 3;
            aiType = NPCID.PossessedArmor;
            animationType = NPCID.Wraith;
            npc.damage = 80;
            npc.defense = 45;
            npc.lifeMax = 3000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 10000f;
            npc.knockBackResist = 0.05f;
            npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            // we would like this npc to spawn in the overworld.
            if (NPC.downedMechBossAny) {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            } else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.spriteDirection = npc.direction;
        }
        public override void AI() {
            npc.TargetClosest(true);
            Vector2 enemy = npc.Center;
            enemy.Y = Main.player[npc.target].Center.Y;
            float y = npc.velocity.Y;
            if (npc.HasValidTarget && Main.player[npc.target].Distance(enemy) > 100f) {
                npc.velocity = new Vector2(npc.direction * 3, y);
            }
        }
    }
}