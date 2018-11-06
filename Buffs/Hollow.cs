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
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) { }

        public override bool ReApply(Player player, int time, int buffIndex) {
            player.buffTime[buffIndex] = time;
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