using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;


namespace DrakSolz.Buffs {
    public class PowerBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Power Within");
            Description.SetDefault("Consuming life for increased damage.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.meleeDamage *= 1.2f;
            player.thrownDamage *= 1.2f;
            player.magicDamage *= 1.2f;
            player.rangedDamage *= 1.2f;
            player.minionDamage *= 1.2f;
            if (Main.time % 60 == 0) {
                if (
                    player.statLifeMax2 <= 99) {
                    player.statLife -= 1;
                }
                if (
                    player.statLifeMax2 >= 100) {
                    player.statLife -= (int)(player.statLifeMax2 * 0.01);
                }
                if (
                    player.statLife <= 0) {

                    player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " couldn't handle the power"), 1, 0);
                }
            }
        }
    }
}