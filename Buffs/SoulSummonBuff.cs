using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs {
    public class SoulSummonBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Soul");
            Description.SetDefault("A soul will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = (XahlicemPlayer) player.GetModPlayer<XahlicemPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Minion.SoulSummonProj>()] > 0) {
                modPlayer.SoulSummon = true;
            }
            if (!modPlayer.SoulSummon) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}