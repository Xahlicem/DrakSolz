using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class RemedyBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Remedy");
            Description.SetDefault("Immunity to Poison, Toxin, and Bleeding!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex) {
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            //int index = player.FindBuffIndex(mod.BuffType<Buffs.ChannelBuff>());
            //if (index != -1) player.buffTime[index] = 0;
        }
    }
}