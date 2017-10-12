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
                    item.type = mod.ItemType<Items.Armor.Vanilla.AdamantiteHood>();
                    break;
                case ItemID.TitaniumHeadgear:
                    item.type = mod.ItemType<Items.Armor.Vanilla.TitaniumHood>();
                    break;
                case ItemID.ChlorophyteHeadgear:
                    item.type = mod.ItemType<Items.Armor.Vanilla.ChlorophyteHat>();
                    break;
                case ItemID.HallowedHeadgear:
                    item.type = mod.ItemType<Items.Armor.Vanilla.HallowedHood>();
                    break;
                case ItemID.OrichalcumHeadgear:
                    item.type = mod.ItemType<Items.Armor.Vanilla.OrichalcumHat>();
                    break;
                case ItemID.PalladiumHeadgear:
                    item.type = mod.ItemType<Items.Armor.Vanilla.PalladiumHat>();
                    break;
            }
        }

        public override void OnCraft(Item item, Recipe recipe) {
            if (item.type == mod.ItemType<Items.Armor.Vanilla.AdamantiteHood>()) item.netDefaults(item.type);
            if (item.type == mod.ItemType<Items.Armor.Vanilla.TitaniumHood>()) item.netDefaults(item.type);
            if (item.type == mod.ItemType<Items.Armor.Vanilla.ChlorophyteHat>()) item.netDefaults(item.type);
            if (item.type == mod.ItemType<Items.Armor.Vanilla.HallowedHood>()) item.netDefaults(item.type);
            if (item.type == mod.ItemType<Items.Armor.Vanilla.OrichalcumHat>()) item.netDefaults(item.type);
            if (item.type == mod.ItemType<Items.Armor.Vanilla.PalladiumHat>()) item.netDefaults(item.type);
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
            }
        }

        public override void UpdateEquip(Item item, Player player) {
            switch (item.type) {
                case ItemID.ShadowHelmet:
                case ItemID.ShadowScalemail:
                case ItemID.ShadowGreaves:
                    player.meleeSpeed *= 0.93f;
                    player.meleeDamage *= 1.03f;
                    player.rangedDamage *= 1.03f;
                    player.magicDamage *= 1.03f;
                    player.minionDamage *= 1.03f;
                    break;
                case ItemID.ObsidianPants:
                    player.fireWalk = true;
                    goto
                case ItemID.ObsidianShirt;
                case ItemID.ObsidianHelm:
                case ItemID.ObsidianShirt:
                    player.rangedDamage *= 1.05f;
                    break;
                case ItemID.GladiatorBreastplate:
                case ItemID.GladiatorLeggings:
                case ItemID.GladiatorHelmet:
                    player.meleeDamage *= 1.05f;
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
                player.ammoCost80 = true;
            }
        }
    }
}