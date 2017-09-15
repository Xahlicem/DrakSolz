using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingBlades : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Blades");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+5% Damage" +
                "\n+5% Crit Chance");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.meleeDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
            player.rangedCrit += 5;
        }
    }
}