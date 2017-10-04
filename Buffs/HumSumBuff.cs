using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class HumSumBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Effigy");
            Description.SetDefault("A humanity sprite is fighting for you.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Minion.HumSumProj>()] > 0) {
                modPlayer.HumSummon = true;
            }
            if (!modPlayer.HumSummon) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}