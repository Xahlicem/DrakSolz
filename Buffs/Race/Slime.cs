using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs.Race

{

    public class Slime : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Slime");
            Description.SetDefault("Power of goo!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();
                    player.noFallDmg = true;
                    player.jumpSpeedBoost += 1;
                    player.jumpBoost = true;
                    player.slippy = true;
                    player.AddBuff(BuffID.Slimed, 10);

                    if (player.wet) {
                        player.gravity = -0.5f;
                    }

        }
    }
}