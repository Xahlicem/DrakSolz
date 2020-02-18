using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DesertSorceress {
    [AutoloadEquip(EquipType.Legs)]
    public class SorceressSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Desert Sorceress Skirt");
            Tooltip.SetDefault("Clothing worn by Desert Sorceresses. So fashionable." +
                "\n+5% magic damage" +
                "\n+15% movement speed" +
                "\n+ decreases mana regen delay");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 9;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.15f;
            player.magicDamage *= 1.05f;
            player.manaRegenDelay -= 5;
        }
    }
}