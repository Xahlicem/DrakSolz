using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Body)]
    public class GiantArmor : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Giant's Armor");
            Tooltip.SetDefault("Become Unstoppable!");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 40;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 0;
            player.statLifeMax2 += 0;
        }
    }
}