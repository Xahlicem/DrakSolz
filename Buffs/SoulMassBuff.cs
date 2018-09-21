using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class SoulMassBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Soul Mass");
            Description.SetDefault("Conjured spheres of arcane magic");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType<Projectiles.Magic.SoulMassProj>()] > 0) {
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