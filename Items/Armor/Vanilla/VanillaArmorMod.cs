using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    class VanillaArmorMod : GlobalItem {
        public override void SetDefaults(Item item) {
            switch (item.type) {
                case ItemID.ObsidianShirt:
                    item.defense = 8;
                    break;
                case ItemID.ObsidianHelm:
                case ItemID.ObsidianPants:
                    item.defense = 7;
                    break;
                case ItemID.GladiatorBreastplate:
                case ItemID.GladiatorLeggings:
                    item.defense = 6;
                    break;
                case ItemID.GladiatorHelmet:
                    item.defense = 5;
                    break;

                case ItemID.AdamantiteHeadgear:
                    item.type = ModContent.ItemType<Items.Armor.Vanilla.AdamantiteHood>();
                    break;
                case ItemID.TitaniumHeadgear:
                    item.type = ModContent.ItemType<Items.Armor.Vanilla.TitaniumHood>();
                    break;
                case ItemID.ChlorophyteHeadgear:
                    item.type = ModContent.ItemType<Items.Armor.Vanilla.ChlorophyteHat>();
                    break;
                case ItemID.HallowedHeadgear:
                    item.type = ModContent.ItemType<Items.Armor.Vanilla.HallowedHood>();
                    break;
                case ItemID.OrichalcumHeadgear:
                    item.type = ModContent.ItemType<Items.Armor.Vanilla.OrichalcumHat>();
                    break;
                case ItemID.PalladiumHeadgear:
                    item.type = ModContent.ItemType<Items.Armor.Vanilla.PalladiumHat>();
                    break;
            }
        }

        public override void OnCraft(Item item, Recipe recipe) {
            if (item.type == ModContent.ItemType<Items.Armor.Vanilla.AdamantiteHood>()) item.netDefaults(item.type);
            if (item.type == ModContent.ItemType<Items.Armor.Vanilla.TitaniumHood>()) item.netDefaults(item.type);
            if (item.type == ModContent.ItemType<Items.Armor.Vanilla.ChlorophyteHat>()) item.netDefaults(item.type);
            if (item.type == ModContent.ItemType<Items.Armor.Vanilla.HallowedHood>()) item.netDefaults(item.type);
            if (item.type == ModContent.ItemType<Items.Armor.Vanilla.OrichalcumHat>()) item.netDefaults(item.type);
            if (item.type == ModContent.ItemType<Items.Armor.Vanilla.PalladiumHat>()) item.netDefaults(item.type);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            switch (item.type) {
                case ItemID.ShadowHelmet:
                case ItemID.ShadowScalemail:
                case ItemID.ShadowGreaves:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "3% increased damage";
                    break;
                case ItemID.ObsidianShirt:
                case ItemID.ObsidianHelm:
                case ItemID.ObsidianPants:
                    tooltips.Insert(3, new TooltipLine(mod, "Tooltip0", "5% increased ranged damage"));
                    break;
                case ItemID.GladiatorBreastplate:
                case ItemID.GladiatorLeggings:
                case ItemID.GladiatorHelmet:
                    tooltips.Insert(3, new TooltipLine(mod, "Tooltip0", "5% increased melee damage"));
                    break;
                case ItemID.MeteorHelmet:
                case ItemID.MeteorSuit:
                case ItemID.MeteorLeggings:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "4% increased fire damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "2% increased fire critical chance"));
                    break;

                case ItemID.NinjaHood:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "5% increased throwing damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "5% increased throwing velocity"));
                    break;
                case ItemID.NinjaPants:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "5% increased throwing damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "5% increased throwing velocity"));
                    break;
                case ItemID.NinjaShirt:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "5% increased throwing damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "5% increased throwing velocity"));
                    break;

                case ItemID.FossilHelm:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "8% increased throwing damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "6% increased throwing velocity"));
                    break;
                case ItemID.FossilPants:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "6% increased throwing damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "6% increased throwing velocity"));
                    break;
                case ItemID.FossilShirt:
                    foreach (TooltipLine line in tooltips)
                        if (line.Name.Equals("Tooltip0")) line.text = "6% increased throwing damage";
                    tooltips.Add(new TooltipLine(mod, "Tooltip1", "8% increased throwing velocity"));
                    break;
            }
        }

        public override void UpdateEquip(Item item, Player player) {
            switch (item.type) {
                case ItemID.ShadowHelmet:
                case ItemID.ShadowScalemail:
                case ItemID.ShadowGreaves:
                    player.meleeSpeed *= 0.93f;
                    player.allDamage += 0.03f;
                    break;
                case ItemID.ObsidianPants:
                    player.fireWalk = true;
                    goto
                case ItemID.ObsidianShirt;
                case ItemID.ObsidianHelm:
                case ItemID.ObsidianShirt:
                    player.rangedDamage += 0.05f;
                    break;
                case ItemID.GladiatorBreastplate:
                case ItemID.GladiatorLeggings:
                case ItemID.GladiatorHelmet:
                    player.meleeDamage += 0.05f;
                    break;
                case ItemID.MeteorHelmet:
                case ItemID.MeteorSuit:
                case ItemID.MeteorLeggings:
                    player.GetModPlayer<MPlayer>().pyromancyDamage += 0.04f;
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 2;
                    break;

                case ItemID.NinjaHood:
                    player.thrownVelocity *= 0.913f;
                    player.thrownDamage += 1.05f;
                    break;
                case ItemID.NinjaPants:
                    player.thrownVelocity *= 1.05f;
                    player.thrownDamage += 1.05f;
                    player.thrownCrit += 10;
                    break;
                case ItemID.NinjaShirt:
                    player.thrownVelocity *= 1.05f;
                    player.thrownDamage += 0.05f;
                    break;

                case ItemID.FossilHelm:
                    player.thrownVelocity *= 0.883f;
                    player.thrownDamage += 0.08f;
                    break;
                case ItemID.FossilPants:
                    player.thrownVelocity *= 1.06f;
                    player.thrownDamage += 0.06f;
                    player.thrownCrit += 15;
                    break;
                case ItemID.FossilShirt:
                    player.thrownVelocity *= 1.08f;
                    player.thrownDamage += 0.06f;
                    break;
                case ItemID.PalladiumLeggings:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 1;
                    break;
                case ItemID.PalladiumBreastplate:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 2;
                    break;
                case ItemID.CobaltBreastplate:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 3;
                    break;
                case ItemID.OrichalcumBreastplate:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 6;
                    break;
                case ItemID.MythrilGreaves:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 3;
                    break;
                case ItemID.TitaniumLeggings:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 3;
                    break;
                case ItemID.TitaniumBreastplate:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 3;
                    break;
                case ItemID.AdamantiteLeggings:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 4;
                    break;
                case ItemID.HallowedPlateMail:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 7;
                    break;
                case ItemID.ChlorophyteGreaves:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 8;
                    break;
                case ItemID.ChlorophytePlateMail:
                    player.GetModPlayer<MPlayer>().pyromancyCrit += 7;
                    break;
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs) {
            if (head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants) return "Obsidian";
            if (head.type == ItemID.GladiatorHelmet && body.type == ItemID.GladiatorBreastplate && legs.type == ItemID.GladiatorLeggings) return "Gladiator";
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateArmorSet(Player player, string set) {
            if (set.Equals("Obsidian")) {
                player.setBonus = "20% chance to not consume ammo";
                player.ammoCost80 = true;
            }
            if (set.Equals("Gladiator")) {
                player.setBonus = "6% increased critical strike chance";
                player.meleeCrit += 6;
                player.rangedCrit += 6;
                player.magicCrit += 6;
                player.thrownCrit += 6;
                player.GetModPlayer<MPlayer>().pyromancyCrit += 6;
                player.ammoCost80 = true;
            }
        }
    }
}