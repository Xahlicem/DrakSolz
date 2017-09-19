using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Channeler {
    [AutoloadEquip(EquipType.Body)]
    public class ChannelerRobe : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Channeler's Robe");
            Tooltip.SetDefault("Description!" +
                "\n+40 Max Health" +
                "\n+40 Max Mana");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 40;
            player.statLifeMax2 += 40;
        }
    }
}