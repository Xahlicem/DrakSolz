using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class TitaniteHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanite Demon Head");
            Tooltip.SetDefault("Or lack thereof!" +
                "\n+20% Magic Damage" +
                "\n+20% Melee Damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.accDivingHelm = true;
            player.blind = true;
            player.dangerSense = true;
            player.meleeDamage *= 1.5f;
        }

        public override bool DrawHead()
		{
			return false;
		}
    }
}