using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {
    public class Spinwheel : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spinwheel");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.scale = 0.8f;
            npc.width = 30;
            npc.height = 68;
            npc.aiStyle = 8;
            aiType = NPCID.Tim;
            animationType = NPCID.Tim;
            npc.damage = 20;
            npc.defense = 9;
            npc.lifeMax = 125;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 225f;
            npc.knockBackResist = 0.1f;
            npc.teleporting = true;
            npc.teleportTime = 2f;
            npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.SpinwheelBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedBoss1)
                return SpawnCondition.Cavern.Chance * 0.08f;
            else return 0f;
        }

        public override void NPCLoot() {
            if (Main.rand.Next(15) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Armor.Father.FatherMask>());
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 7.5f / magnitude;

        }
        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 0.01f / magnitude;

            return vector;
        }
    }
}