using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class ThePursuer : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Pursuer");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.width = 40;
            npc.scale *= 0.70f;
            npc.height = 80;
            npc.aiStyle = 3;
            aiType = NPCID.PossessedArmor;
            animationType = NPCID.Wraith;
            npc.damage = 65;
            npc.defense = 32;
            npc.lifeMax = 800;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 2500f;
            npc.knockBackResist = 0.05f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.PursuerBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedMechBossAny) {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            } else return 0f;
        }
        public override void FindFrame(int frameHeight) {
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