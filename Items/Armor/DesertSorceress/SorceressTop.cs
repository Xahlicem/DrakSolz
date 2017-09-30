using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DesertSorceress {
    [AutoloadEquip(EquipType.Body)]
    public class SorceressTop : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Desert Sorceress Top");
            Tooltip.SetDefault("Clothing worn by Desert Sorceresses. So fashionable." +
                "\n+10% magic damage" +
                "\n+ increases mana star grab range");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 8;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.1f;
            player.manaMagnet = true;
        }
    }
}