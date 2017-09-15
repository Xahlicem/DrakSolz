using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Misc {
    public class BeeSoul : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sweet Soul");
            Tooltip.SetDefault("Soul of the Queen Bee" +
                "\n+2200 Souls when consumed.");
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
            item.rare = 4;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.ManaEffect(2200);
            player.GetModPlayer<XahlicemPlayer>().SoulTicks += 52;
            return true;
        }
    }
}