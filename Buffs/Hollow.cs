using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class Hollow : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Hollow");
            Description.SetDefault("Feeling a little empty?");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            Main.persistentBuff[Type] = true;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer p = player.GetModPlayer<DrakSolzPlayer>();
            if (p.LastHurt <= 600) player.buffTime[buffIndex]++;
            else if (p.LastHurt >= 3600) player.buffTime[buffIndex]--;
            int life = (int)((player.buffTime[buffIndex] + 1) / 300f);
            player.statLifeMax2 -= life;
            int min = 20 + (int)(p.Vit * 2.5f) + (p.Vit > 20 ? p.Vit - 20 : 0);
            if (player.statLifeMax2 < min) player.statLifeMax2 = min;
            if (Main.netMode == NetmodeID.MultiplayerClient) GetPacket(MessageType.FromClieBuff, player, buffIndex);
        }

        public override bool ReApply(Player player, int time, int buffIndex) {
            player.buffTime[buffIndex] += time;
            return true;
        }

        public ModPacket GetPacket(MessageType packetType, Player player, int buffIndex) {
            int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) packetType);
            packet.Write(player.whoAmI);
            packet.Write(buffIndex);
            packet.Write(player.buffTime[buffIndex]);
            return packet;
        }
    }
}