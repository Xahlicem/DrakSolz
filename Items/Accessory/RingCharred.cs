using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingCharred : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orange Charred Ring");
            Tooltip.SetDefault("Inflicts fire damage on attack" +
                "\nImmunity to Fire");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 12, 50, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.lavaRose = true;
            player.fireWalk = true;
            player.AddBuff(BuffID.WeaponImbueFire, 2);
            player.AddBuff(BuffID.Warmth, 2);
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
        }
    }
}