using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    // This ModNPC serves as an example of a complete AI example.
    public class Ravelord : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ravelord");
            Main.npcFrameCount[npc.type] = 17; // make sure to set this for your modnpcs.
        }

        public override void SetDefaults() {
            npc.width = 55;
            npc.scale *= 1.5f;
            npc.height = 65;
            npc.aiStyle = 3;
            aiType = NPCID.PossessedArmor;
            animationType = NPCID.PossessedArmor;
            npc.damage = 120;
            npc.defense = 55;
            npc.lifeMax = 5500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            //npc.alpha = 175;
            //npc.color = new Color(0, 80, 255, 100);
            npc.value = 50000f;
            npc.knockBackResist = 0.1f;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.RavelordBanner>();
            npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedGolemBoss) {
                return SpawnCondition.Cavern.Chance * 0.2f;
            } else return 0f;
        }
        public override void FindFrame(int frameHeight) {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.spriteDirection = npc.direction;
        }
        public override void NPCLoot() {
            if (Main.rand.Next(20) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Melee.GravelordSword>());
        }

    }
}