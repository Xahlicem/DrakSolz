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
            else return base.CanUseItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            for (int i = 0; i < tooltips.Count; i++)
                if (tooltips[i].Name.Equals("Tooltip0")) {
                    if (item.type == ItemID.LifeCrystal)
                        tooltips[i].text = "Makes you whole and increases life regeneration for 5 minutes";
                    if (item.type == ItemID.LifeFruit)
                        tooltips[i].text = "Makes you whole and increases life regeneration for 1 minute";
                    if (item.type == ItemID.ManaCrystal)
                        tooltips[i].text = "Increases mana regeneration and magic damage for 1 minute";
                }
        }

        public override bool ConsumeItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit) {
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal) ? 5 : 1));

                player.GetModPlayer<DrakSolzPlayer>().DecreaseHurtWait(3600);
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(60 * 60 * ((item.type == ItemID.LifeCrystal) ? 30 : 5));
                return true;
            }
            if (item.type == ItemID.ManaCrystal) {
                player.AddBuff(BuffID.ManaRegeneration, 60 * 60 * 1);
                player.AddBuff(BuffID.MagicPower, 60 * 60 * 1);
                return true;
            }
            return base.ConsumeItem(item, player);
        }

        public override bool UseItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit || item.type == ItemID.ManaCrystal) return true;
            else return base.UseItem(item, player);
        }
    }
    public class GoblinStandardMod : GlobalItem {
        public override bool UseItem(Item item, Player player) {
            if (item.type != ItemID.GoblinBattleStandard) return base.UseItem(item, player);
            //int i = player.statLifeMax;
            player.statLifeMax += 200;
            bool ret = base.UseItem(item, player);
            //player.statLifeMax = i;
            return ret;
        }
    }

    public class SummonMod : GlobalItem {
        public override void SetDefaults(Item item) {
            if (item.summon != true) return;
            switch (item.type) {
                case ItemID.SlimeStaff:
                    item.mana = 10;
                    item.damage = 11;
                    break;
                case ItemID.HornetStaff:
                    item.mana = 20;
                    item.damage = 20;
                    break;
                case ItemID.ImpStaff:
                    item.mana = 40;
                    item.damage = 40;
                    break;

                case ItemID.SpiderStaff:
                    item.mana = 60;
                    break;
                case ItemID.OpticStaff:
                    item.mana = 80;
                    item.damage = 50;
                    break;
                case ItemID.PirateStaff:
                    item.mana = 80;
                    break;
                case ItemID.PygmyStaff:
                    item.mana = 100;
                    item.damage = 60;
                    break;
                case ItemID.XenoStaff:
                    item.mana = 140;
                    item.damage = 70;
                    break;
                case ItemID.RavenStaff:
                    item.mana = 120;
                    break;
                case ItemID.TempestStaff:
                    item.mana = 180;
                    break;
                case ItemID.DeadlySphereStaff:
                    item.mana = 150;
                    break;
                case ItemID.StardustDragonStaff:
                    item.mana = 200;
                    item.damage = 35;
                    break;
                case ItemID.StardustCellStaff:
                    item.mana = 200;
                    break;

                case ItemID.QueenSpiderStaff:
                    item.mana = 100;
                    item.damage = 50;
                    break;
                case ItemID.StaffoftheFrostHydra:
                    item.mana = 150;
                    item.damage = 120;
                    break;
                case ItemID.MoonlordTurretStaff:
                    item.mana = 200;
                    item.damage = 90;
                    break;
                case ItemID.RainbowCrystalStaff:
                    item.mana = 200;
                    item.damage = 200;
                    break;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            for (int i = 0; i < tooltips.Count; i++) {
                if (tooltips[i].text.Contains("summon damage"))
                    tooltips[i].text = tooltips[i].text.Replace("summon", "miracle");
                if (tooltips[i].text.Contains("minion damage"))
                    tooltips[i].text = tooltips[i].text.Replace("minion", "miracle");
                if (tooltips[i].text.Contains("minions damage"))
                    tooltips[i].text = tooltips[i].text.Replace("minions", "miracle");
            }
        }
    }

    public class MeleeThrow : GlobalItem {

        public override void SetDefaults(Item item) {
            if (item == null) return;
            if (item.modItem != null) return;
            Projectile p = new Projectile();
            if (item.shoot != 0 || item.shoot != -1) p.CloneDefaults(item.shoot);
            if (ItemID.Sets.Yoyo[item.type] || p.aiStyle == 99 || p.aiStyle == 3 ||
                item.type == ItemID.VampireKnives || item.type == ItemID.ShadowFlameKnife ||
                item.type == ItemID.FlyingKnife || item.type == ItemID.DayBreak) {
                item.melee = false;
                item.thrown = true;
            }
        }
    }
}