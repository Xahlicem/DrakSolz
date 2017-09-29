using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingHavels : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Havel's Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+No Knockback" +
                "\n+Immunity to Stone Debuff");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 8;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.noKnockback = true;
            player.buffImmune[BuffID.Stoned] = true;
        }
    }
}