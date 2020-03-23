using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class WarmthBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Warmth");
            Description.SetDefault("So nice and toasty.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            if (Main.time % 20 == 0 && player.statLife < player.statLifeMax2) {
                player.statLife += (int)(player.statLifeMax2 * 0.01);
                player.HealEffect((int)(player.statLifeMax2 * 0.01));
            }
            int index = player.FindBuffIndex(ModContent.BuffType<Buffs.Hollow>());
            if (index != -1) player.buffTime[index]--;
        }
    }
}