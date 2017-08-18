using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
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
            item.defense = 2;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.noKnockback = true;
            player.buffImmune[BuffID.Stoned] = true;
        }
    }
}