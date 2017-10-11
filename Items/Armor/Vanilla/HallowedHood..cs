using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hallowed Hood");
            Tooltip.SetDefault("Increases maximum mana by 100" +
                "\n12% increased magic damage and critical strike chance");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.HallowedHeadgear);
            item.defense = refItem.defense;
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = refItem.width;
            item.height = refItem.height;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.12f;
            player.magicCrit += 12;
            player.statManaMax2 += 100;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-20% reduced mana Usage");
            player.manaCost *= 0.80f;
        }

        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawOutlines = true;
        }

        public override bool DrawHead() { return false; }
    }
}