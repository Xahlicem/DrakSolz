using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs

{

    public class Firelink : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Firelinked");
            Description.SetDefault("So nice and toasty.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.blackout = true;
            if (Main.time % 30 == 0 && player.statLife < player.statLifeMax2) {
                player.statLife += (int)(player.statLifeMax2 * 0.025);
                player.HealEffect((int)(player.statLifeMax2 * 0.025));
            }
        }
    }
}