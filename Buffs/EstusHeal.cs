using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            int i2 = 0;
            if (NPC.downedMoonlord) {
                i2 += 1;
            }
            if (NPC.downedAncientCultist) {
                i2 += 1;
            }
            if (NPC.downedGolemBoss) {
                i2 += 1;
            }
            if (NPC.downedPlantBoss) {
                i2 += 1;
            }
            if (NPC.downedMechBossAny) {
                i2 += 1;
            }
            if (Main.hardMode) {
                i2 += 1;
            }
            if (NPC.downedBoss3) {
                i2 += 1;
            }
            if (NPC.downedBoss2) {
                i2 += 1;
            }
            if (NPC.downedBoss1) {
                i2 += 1;
            }
            if (Main.time % 10 == 1) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(240 + (i2 * 80));
            }
            if (Main.time % 10 == 5) {
                player.statLife += (1 + i2 + player.GetModPlayer<DrakSolzPlayer>().REstus);
                player.HealEffect(1 + i2 + player.GetModPlayer<DrakSolzPlayer>().REstus);
            }
            if (Main.time % 10 == 5 && player.GetModPlayer<DrakSolzPlayer>().RAEstus >= 1) {
                if (player.statMana < player.statManaMax2 + player.statManaMax)
                player.statMana += (10);
                player.ManaEffect (10);
            }
            if (player.buffTime[buffIndex] == 1) {
                if (!player.HasBuff(BuffID.PotionSickness)) {
                    foreach (Item i in player.inventory) {
                        if (i.type == ModContent.ItemType<Items.Misc.EstusFlask>()) {
                            if (i.stack > 1) {
                                i.stack -= 1;
                                modPlayer.Estus += 1;
                                return;
                            } else {
                                i.netDefaults(ModContent.ItemType<Items.Misc.EmptyFlask>());
                                modPlayer.Estus += 1;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}