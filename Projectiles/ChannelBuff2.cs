using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Projectiles {
    public class ChannelBuff2 : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Channeler's Perfect Dance");
            Description.SetDefault("Damage Increased Greatly!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }
        public override void Update(Player player, ref int buffIndex) {
            player.moveSpeed += 0.25f;
            player.maxRunSpeed += 0.50f;
            player.maxFallSpeed += 4.0f;
            player.jumpSpeedBoost += 2.50f;
            player.pickSpeed += 0.50f;
            player.meleeSpeed += 0.25f;
            player.magicDamage *= 1.4f;
            player.thrownDamage *= 1.4f;
            player.rangedDamage *= 1.4f;
            player.minionDamage *= 1.4f;
            player.meleeDamage *= 1.4f;
        }
    }
}