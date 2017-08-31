using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs

{

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
            if (player.GetModPlayer<XahlicemPlayer>().LastHurt <= 600) player.buffTime[buffIndex]++;
            else if (player.GetModPlayer<XahlicemPlayer>().LastHurt >= 3600) player.buffTime[buffIndex]--;
            int life = (int)((player.buffTime[buffIndex] + 1) / 300f);
            player.statLifeMax2 -= life;
            if (player.statLifeMax2 < 20) player.statLifeMax2 = 20;
            if (Main.netMode == NetmodeID.MultiplayerClient) GetPacket(XModMessageType.FromClieBuff, player, buffIndex);
        }

        public override bool ReApply(Player player, int time, int buffIndex) {
            player.buffTime[buffIndex] += time;
            return true;
        }

        public ModPacket GetPacket(XModMessageType packetType, Player player, int buffIndex) {
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