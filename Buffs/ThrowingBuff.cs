using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class ThrowingBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Throwing Practice");
            Description.SetDefault("Thrown velocity increased by 100%");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex) {
            player.thrownVelocity *= 2;
            player.yoyoString = true;
        }
    }
}