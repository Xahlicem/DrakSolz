using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class Firelink : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Firelinked");
            Description.SetDefault("So nice and toasty.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            if (Main.time % 30 == 0 && player.statLife < player.statLifeMax2) {
                player.statLife += (int)(player.statLifeMax2 * 0.01);
                player.HealEffect((int)(player.statLifeMax2 * 0.01));
            }

            int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
            if (index != -1) player.buffTime[index]--;
            int x = player.FindBuffIndex(mod.BuffType<Buffs.ScrollMana>());
            if (x!= -1) player.buffTime[x]= 0;
        }
    }
}