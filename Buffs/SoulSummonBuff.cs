using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class SoulSummonBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Soul");
            Description.SetDefault("A soul will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);
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