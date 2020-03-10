using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DrakSolz.NPCs {
    class DSGlobalNPC : GlobalNPC {

        public override bool InstancePerEntity {
            get {
                return true;
            }
        }

        public bool Healp = false;

        public override void ResetEffects(NPC npc) {
            Healp = false;
            if (npc.HasBuff(BuffID.OnFire) || npc.HasBuff(BuffID.ShadowFlame) || npc.HasBuff(BuffID.CursedInferno) || npc.HasBuff(BuffID.Frostburn)) {
                if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.FireBuff>())) {
                    npc.AddBuff(204, 20, true);
                }
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage) {
            if (Healp) {
                npc.lifeRegen += 10000;
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
            float mul = 1f;
            if (NPC.downedSlimeKing) mul *= 1.1f;
            if (NPC.downedQueenBee) mul *= 1.1f;
            if (NPC.downedBoss1) mul *= 1.1f;
            if (NPC.downedBoss2) mul *= 1.1f;
            if (NPC.downedBoss3) mul *= 1.1f;
            if (Main.hardMode) mul *= 0.75f;
            if (NPC.downedMechBoss1) mul *= 1.1f;
            if (NPC.downedMechBoss2) mul *= 1.1f;
            if (NPC.downedMechBoss3) mul *= 1.1f;
            if (NPC.downedPlantBoss) mul *= 1.1f;
            if (NPC.downedGolemBoss) mul *= 1.1f;
            if (NPC.downedAncientCultist) mul *= 0.6f;
            if (NPC.downedFishron) mul *= 1.1f;
            if (NPC.downedMoonlord) mul *= 1.4f;
            spawnRate = (int)(spawnRate / mul);
            maxSpawns = (int)(maxSpawns * mul);
        }
        public override void SetDefaults(NPC npc) {
            if (npc.type == NPCID.KingSlime) {
                if (Main.hardMode){
                npc.lifeMax = 1600;
                npc.damage = 26;
                }
                else {
                npc.lifeMax = 2250;
                npc.damage = 44;
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot) {
            if (type == NPCID.TravellingMerchant) {
                if (Main.hardMode) {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Tiles.LotteryMachine>());
                    shop.item[nextSlot].shopCustomPrice = 2000000;
                }
            }
        }
    }
}