using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHat : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Palladium Hat");
            Tooltip.SetDefault("7% increased magic damage and critical strike chance" +
                "\nIncreases maximum mana by 60");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.PalladiumHeadgear);
            item.defense = refItem.defense;
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = refItem.width;
            item.height = refItem.height;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.07f;
            player.magicCrit += 7;
            player.statManaMax2 += 60;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Greatly increases life regeneration after striking an enemy");
            player.onHitRegen = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = true;
        }
    }
}