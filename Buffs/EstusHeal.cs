using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DrakSolz.Items.Souls;

namespace DrakSolz.Buffs {
    public class EstusHeal : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Estus");
            Description.SetDefault("Delicious flask.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            player.accRunSpeed = 0;
            player.moveSpeed = 0;
            player.jump = 0;
            int extra = 0;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_MOON_LORD)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_LUNATIC_CULTIST)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_GOLEM)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_PLANTERA)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_DESTROYER)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_WALL)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_SKELETRON)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_EATER)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_BRAIN)) extra++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_EYE)) extra++;
            if (Main.time % 10 == 1) {
                modPlayer.DecreaseHollow(240 + (extra * 80));
            }
            if (Main.time % 10 == 5) {
                player.statLife += (1 + extra + modPlayer.REstus);
                player.HealEffect(1 + extra + modPlayer.REstus);
                if (player.statMana < player.statManaMax2 + player.statManaMax && modPlayer.RAEstus > 0) {
                    player.statMana += (modPlayer.RAEstus);
                    player.ManaEffect (modPlayer.RAEstus);
                }
            }
            if (player.buffTime[buffIndex] == 1) {
                if (!player.HasBuff(BuffID.PotionSickness)) foreach (Item i in player.inventory)
                        if (i.type == ModContent.ItemType<Items.Misc.EstusFlask>()) {
                            if (i.stack > 1) {
                                i.stack--;
                                modPlayer.Estus++;
                            }
                            else i.netDefaults(ModContent.ItemType<Items.Misc.EmptyFlask>());
                        }
            }
        }
        public static bool HasDownedBoss(DrakSolzPlayer modPlayer, int bossSoulPlace) {
            return ((modPlayer.BossSouls & bossSoulPlace) > 0);
        }
    }
}