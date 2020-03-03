using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class ChannelBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Channeler's Dance");
            Description.SetDefault("Damage Increased!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex) {
            float increase = 1.15f;
            player.moveSpeed += 0.10f;
            player.maxRunSpeed += 0.25f;
            player.maxFallSpeed += 2.0f;
            player.jumpSpeedBoost += 1.5f;
            player.pickSpeed += 0.20f;
            player.meleeSpeed += 0.10f;
            player.allDamage *= increase;
        }
    }
}