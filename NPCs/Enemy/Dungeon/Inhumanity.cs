using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.Dungeon {
    public class Inhumanity : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Inhumanity");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.CursedSkull);
            npc.scale = 1.25f;
            npc.width = 25;
            npc.height = 40;
            npc.aiStyle = 10;
            aiType = NPCID.CursedSkull;
            animationType = NPCID.Wraith;
            npc.noTileCollide = true;
            npc.damage = 80;
            npc.defense = 25;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 250f;
            npc.knockBackResist = 0.25f;
            npc.alpha = 50;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.InhumanityBanner>();
        }

        public override int SpawnNPC(int tileX, int tileY) {
            npc.scale += Main.rand.NextFloat(0.25f);
            return base.SpawnNPC(tileX, tileY);
        }

        public override void NPCLoot() {
            //if (Main.rand.Next(150) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Summon.EffigyStaff>());
        }
    }
}