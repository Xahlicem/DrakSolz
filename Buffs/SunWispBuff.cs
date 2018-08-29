using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class SunWispBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Sun Wisp");
            Description.SetDefault("A Sun Wisp has acknowledged your radiance.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Minion.SunSumProj>()] > 0) {
                modPlayer.SunSummon = true;
            }
            if (!modPlayer.SunSummon) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}