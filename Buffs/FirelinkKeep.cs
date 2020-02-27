using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class FirelinkKeep : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Firelink Power");
            Description.SetDefault("Repels the undead curse.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            if (Main.time % 60 == 0 && player.statLife < player.statLifeMax2) {
                player.statLife += (int)(player.statLifeMax2 * 0.01);
                player.HealEffect((int)(player.statLifeMax2 * 0.01));
            }
        }
    }
}