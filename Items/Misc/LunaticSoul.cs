using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Misc {
    public class LunaticSoul : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Illusory Soul");
            Tooltip.SetDefault("Soul of the Lunatic Cultist" +
                "\n+35000 Souls when consumed.");
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
            item.rare = 8;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.ManaEffect(35000);
            player.GetModPlayer<XahlicemPlayer>().SoulTicks += 135;
            return true;
        }
    }
}