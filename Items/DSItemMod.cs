using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items {

    public class ManaHealth : GlobalItem {
        public override bool CanUseItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit || item.type == ItemID.ManaCrystal) return true;
            else return base.ConsumeItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (tooltips.Capacity < 2) return;
            if (item.type == ItemID.LifeCrystal) {
                tooltips[tooltips.Capacity - 1].text = "Makes you whole and increases life regeneration for 5 minutes";
            }
            if (item.type == ItemID.LifeFruit) {
                tooltips[tooltips.Capacity - 2].text = "Makes you whole and increases life regeneration for 1 minute";
            }
            if (item.type == ItemID.ManaCrystal) {
                tooltips[tooltips.Capacity - 2].text = "Increases mana regeneration and magic damage for 1 minute";
            }
        }

        public override bool ConsumeItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit) {
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal) ? 5 : 1));

                int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
                if (index != -1) player.buffTime[index] = 0;
            }
            if (item.type == ItemID.ManaCrystal) {
                player.AddBuff(BuffID.ManaRegeneration, 60 * 60 * 1);
                player.AddBuff(BuffID.MagicPower, 60 * 60 * 1);
            }
            return base.ConsumeItem(item, player);
        }

        public override bool UseItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit) {
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal) ? 5 : 1));

                int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
                if (index != -1) player.buffTime[index] = 0;
                return true;
            }
            if (item.type == ItemID.ManaCrystal) {
                player.AddBuff(BuffID.ManaRegeneration, 60 * 60 * 1);
                player.AddBuff(BuffID.MagicPower, 60 * 60 * 1);
                return true;
            }
            return base.UseItem(item, player);
        }
    }

    public class SummonMod : GlobalItem {
        public override void SetDefaults(Item item) {
            if (item.type == ItemID.SlimeStaff) {
                item.mana *= 1;

            }
        }
    }

    public class MeleeThrow : GlobalItem {

        public override void SetDefaults(Item item) {
            if (item == null || item.type >= ItemID.Sets.Yoyo.Length || DrakSolz.ListMeleeThrow == null) return;
            if (ItemID.Sets.Yoyo[item.type] || DrakSolz.ListMeleeThrow.Contains(item.type)) {
                item.melee = false;
                item.thrown = true;
            }
        }
    }
}