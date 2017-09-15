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
            player.moveSpeed += 0.10f;
            player.maxRunSpeed += 0.25f;
            player.maxFallSpeed += 2.0f;
            player.jumpSpeedBoost += 1.25f;
            player.pickSpeed += 0.10f;
            player.meleeSpeed += 0.10f;
            player.magicDamage *= 1.25f;
            player.thrownDamage *= 1.25f;
            player.rangedDamage *= 1.25f;
            player.minionDamage *= 1.25f;
            player.meleeDamage *= 1.25f;
        }
    }
}