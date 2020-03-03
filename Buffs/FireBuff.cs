using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace DrakSolz.Buffs {
    public class FireBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Burning Soul");
            Description.SetDefault("On Fire damage increased");
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex) {
            player.thrownVelocity *= 2;
            player.yoyoString = true;
        }
    }
}