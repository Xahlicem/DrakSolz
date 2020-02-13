using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class CrystalSoulMassBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Crystal Soul Mass");
            Description.SetDefault("Conjured spheres of crystalized arcane magic");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Magic.CrystalSoulMassProj>()] > 0) {
                modPlayer.SoulMassSum = true;
            }
            if (!modPlayer.SoulMassSum) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 5;
        }
    }
}