using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class SlipperyBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Slippery");
            Description.SetDefault("Get a grip!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            Main.persistentBuff[Type] = true;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.slippy2 = true;
        }
    }
}