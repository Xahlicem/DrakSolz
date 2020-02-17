using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class IronFleshBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Iron Flesh");
            Description.SetDefault("Defense Increased Greatly!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex) {
            player.moveSpeed -= 0.25f;
            player.maxRunSpeed -= 0.50f;
            player.maxFallSpeed += 4.0f;
            player.jumpSpeedBoost -= 0.50f;
            player.statDefense += 10;
            player.noKnockback = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.WaterWalking] = true;
            //int index = player.FindBuffIndex(ModContent.BuffType<Buffs.ChannelBuff>());
            //if (index != -1) player.buffTime[index] = 0;
        }
    }
}