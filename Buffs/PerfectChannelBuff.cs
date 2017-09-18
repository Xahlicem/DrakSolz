using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class PerfectChannelBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Channeler's Perfect Dance");
            Description.SetDefault("Damage Increased Greatly!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }
        public override void Update(Player player, ref int buffIndex) {
            float increase = 1.3f;
            player.moveSpeed += 0.25f;
            player.maxRunSpeed += 0.50f;
            player.maxFallSpeed += 4.0f;
            player.jumpSpeedBoost += 2.50f;
            player.pickSpeed += 0.50f;
            player.meleeSpeed += 0.25f;
            player.magicDamage *= increase;
            player.thrownDamage *= increase;
            player.rangedDamage *= increase;
            player.minionDamage *= increase;
            player.meleeDamage *= increase;

            int index = player.FindBuffIndex(mod.BuffType<Buffs.ChannelBuff>());
            if (index != -1) player.buffTime[index] = 0;
        }
    }
}