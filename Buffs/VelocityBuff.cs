using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class VelocityBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Velocity");
            Description.SetDefault("Increased Movement Speed!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex) {
            player.moveSpeed *= 1.20f;
            player.maxRunSpeed *= 1.20f;
            player.jumpSpeedBoost *= 1.10f;
            player.buffImmune[BuffID.Slow] = true;
            //int index = player.FindBuffIndex(ModContent.BuffType<Buffs.ChannelBuff>());
            //if (index != -1) player.buffTime[index] = 0;
        }
    }
}