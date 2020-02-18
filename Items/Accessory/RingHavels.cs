using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingHavels : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Havel's Ring");
            Tooltip.SetDefault("Grants immunity to knockback" +
                "\nImmunity to petrification");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 8;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.noKnockback = true;
            player.buffImmune[BuffID.Stoned] = true;
        }
    }
}