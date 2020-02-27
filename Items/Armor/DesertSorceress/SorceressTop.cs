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
                "\n+6% fire damage" +
                "\n+ increases mana star grab range");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.06f;
            player.manaMagnet = true;
        }
    }
}