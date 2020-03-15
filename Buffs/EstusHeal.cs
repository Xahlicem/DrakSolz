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
            int amount = modPlayer.EstusHealth;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_MOON_LORD)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_LUNATIC_CULTIST)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_GOLEM)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_PLANTERA)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_DESTROYER)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_WALL)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_SKELETRON)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_EATER)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_BRAIN)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_EYE)) amount++;
            if (Main.time % 10 == 1) {
                modPlayer.DecreaseHollow(240 + (amount * 80));
            }
            if (Main.time % 10 == 5) {
                player.statLife += (amount);
                player.HealEffect(amount);
                if (player.statMana < player.statManaMax2 + player.statManaMax && modPlayer.EstusMana > 0) {
                    player.statMana += (modPlayer.EstusMana);
                    player.ManaEffect (modPlayer.EstusMana);
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