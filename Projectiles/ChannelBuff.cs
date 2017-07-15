using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Projectiles
{
    public class ChannelBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Channeler's Dance");
            Description.SetDefault("Damage Increased!");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;

        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.05f;
            player.magicDamage *= 1.25f;
            player.thrownDamage *= 1.25f;
            player.rangedDamage *= 1.25f;
            player.minionDamage *= 1.25f;
            player.meleeDamage *= 1.25f;
        }
    }
}