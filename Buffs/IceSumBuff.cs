using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class IceSumBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Crystal Wisp");
            Description.SetDefault("A Crystal Wisp has acknowledged your Brilliance.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minion.IceSum>()] > 0) {
                modPlayer.IceSummon = true;
            }
            if (!modPlayer.IceSummon) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}