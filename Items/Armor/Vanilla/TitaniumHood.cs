using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanium Hood");
            Tooltip.SetDefault("16% increased magic damage and 7% increased magic critical strike chance" +
                "\nIncreases maximum mana by 100");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.TitaniumHeadgear);
            item.defense = refItem.defense;
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = refItem.width;
            item.height = refItem.height;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.16f;
            player.magicCrit += 7;
            player.statManaMax2 += 100;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Become immune after striking an enemy");
            player.onHitDodge = true;
        }

        public override bool DrawHead() { return false; }
    }
}