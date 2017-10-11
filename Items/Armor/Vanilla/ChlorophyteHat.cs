using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Vanilla {
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHat : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chlorophyte Hat");
            Tooltip.SetDefault("Increases maximum mana by 80 and reduces mana usage by 17%" +
                "\n16% increased magic damage");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.CloneDefaults(ItemID.ChlorophyteHeadgear);
            item.defense = refItem.defense;
            item.value = refItem.value;
            item.rare = refItem.rare;
            item.width = refItem.width;
            item.height = refItem.height;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.16f;
            player.statManaMax2 += 80;
            player.manaCost *= 0.83f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Summons a powerful leaf crystal to shoot at nearby enemies");
            player.AddBuff(BuffID.LeafCrystal, 5);
        }

        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawOutlines = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = true;
        }
    }
}