using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class SwordSumBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Summoned Sword");
            Description.SetDefault("A Sword has acknowledged your valor.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minion.SwordSumProj>()] > 0) {
                modPlayer.DungeonSummon = true;
            }
            if (!modPlayer.DungeonSummon) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}