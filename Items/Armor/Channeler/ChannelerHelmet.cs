using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Channeler {
    [AutoloadEquip(EquipType.Head)]
    public class ChannelerHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Channeler's Helmet");
            Tooltip.SetDefault("Description!" +
                "\n+20% Damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.magicDamage *= 1.2f;
            player.meleeDamage *= 1.2f;
            player.rangedDamage *= 1.2f;
            player.minionDamage *= 1.2f;
            player.thrownDamage *= 1.2f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.Channeler.ChannelerRobe>() && legs.type == mod.ItemType<Items.Armor.Channeler.ChannelerSkirt>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Channeler's Perfect Dance" +
                "\n+1 Accessory Slot");
        }
    }
}