using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class ScrollMana : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Drained");
            Description.SetDefault("Maximum mana decreased.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            Main.persistentBuff[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.statManaMax2 -= (int)((player.buffTime[buffIndex] + 1) / 360);
        }

        public override bool ReApply(Player player, int time, int buffIndex) {
            player.buffTime[buffIndex] += time;
            return false;
        }
    }
}