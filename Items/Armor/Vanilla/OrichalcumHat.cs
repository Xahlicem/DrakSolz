using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumHat : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orichalcum Hat");
            Tooltip.SetDefault("18% increased magic critical strike chance" +
                "\nIncreases maximum mana by 80");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.OrichalcumHeadgear);
            item.defense = refItem.defense;
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = refItem.width;
            item.height = refItem.height;
        }

        public override void UpdateEquip(Player player) {
            player.magicCrit += 18;
            player.statManaMax2 += 80;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Flower petals will fall on your target for extra damage");
            player.onHitPetal = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = true;
        }
    }
}