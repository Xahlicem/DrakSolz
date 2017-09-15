using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Misc {
    public class WallSoul : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cadaverous Soul");
            Tooltip.SetDefault("Soul of the Wall of Flesh" +
                "\n+5000 Souls when consumed.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.ManaCrystal);
            item.width = refItem.width;
            item.height = refItem.height;
            item.useStyle = refItem.useStyle;
            item.UseSound = refItem.UseSound;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = 5;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.ManaEffect(5000);
            player.GetModPlayer<XahlicemPlayer>().SoulTicks += 80;
            return true;
        }
    }
}