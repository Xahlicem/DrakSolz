using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.NPCs
{
    public class Channeler : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Channeler");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GoblinArcher];
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 56;
            npc.damage = 100;
            npc.defense = 50;
            npc.lifeMax = 10000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 3;
            aiType = NPCID.GoblinArcher;
            animationType = NPCID.GoblinArcher;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Dungeon.Chance * 0.5f;
            //return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                int dustType = Main.rand.Next(139, 143);
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
    }
}