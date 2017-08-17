using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs.Race

{

    public class Demon : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Demon");
            Description.SetDefault("Power of Hell!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();
            player.rangedDamage *= 0.8f;
            player.magicDamage *= 1.25f;
            player.manaCost *= 1.25f;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.8);

            player.buffImmune[BuffID.OnFire] = true;
            player.lavaRose = true;
            player.fireWalk = true;
            player.lavaMax = 600;
            if (Main.myPlayer == player.whoAmI && Main.time % 30 == 0 && modPlayer.wet) {
                player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " couldn't stand the water."), 5, 0, false, false, false, 0);
            }
        }
    }
}