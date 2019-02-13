using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Adamantite Hood");
            Tooltip.SetDefault("Increases maximum mana by 800" +
                "\n11% increased magic damage and critical strike chance");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.AdamantiteHeadgear);
            item.defense = refItem.defense;
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = refItem.width;
            item.height = refItem.height;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.11f;
            player.magicCrit += 11;
            player.statManaMax2 += 80;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-19% reduced mana Usage");
            player.manaCost *= 0.81f;
        }

        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawOutlines = true;
        }

        public override bool DrawHead() { return false; }
    }
}