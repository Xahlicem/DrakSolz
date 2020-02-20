using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class EstusHeal : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Estus");
            Description.SetDefault("Delicious flask.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.accRunSpeed = 0;
            player.moveSpeed = 0;
            player.jump = 0;
            if (Main.time % 10 == 5) {
                if (NPC.downedMoonlord) {

                    player.statLife += 10;
                    player.HealEffect(10);

                } else if (NPC.downedAncientCultist) {

                    player.statLife += 9;
                    player.HealEffect(9);

                } else if (NPC.downedGolemBoss) {

                    player.statLife += 8;
                    player.HealEffect(8);

                } else if (NPC.downedPlantBoss) {

                    player.statLife += 7;
                    player.HealEffect(7);

                } else if (NPC.downedMechBossAny) {

                    player.statLife += 6;
                    player.HealEffect(6);

                } else if (Main.hardMode) {

                    player.statLife += 5;
                    player.HealEffect(5);

                } else if (NPC.downedBoss3) {

                    player.statLife += 4;
                    player.HealEffect(4);

                } else if (NPC.downedBoss2) {

                    player.statLife += 3;
                    player.HealEffect(3);

                } else if (NPC.downedBoss1) {

                    player.statLife += 2;
                    player.HealEffect(2);

                } else {

                    player.statLife += 1;
                    player.HealEffect(1);
                }
            }
        }
    }
}