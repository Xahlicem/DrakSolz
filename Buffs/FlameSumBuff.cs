using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class FlameSumBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Flamewreath");
            Description.SetDefault("A Sun Wisp has acknowledged your Glory.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minion.FlameSum>()] > 0) {
                modPlayer.FireSummon = true;
            }
            if (!modPlayer.FireSummon) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}