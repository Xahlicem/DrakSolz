using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class RetSoul : ModItem {
        public const int PLACE = 1 << 8;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Malevolent Soul");
            Tooltip.SetDefault("Soul of Retinazer" +
                "\n+7500 Souls when consumed.");
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
            item.rare = 6;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.ManaEffect(7500);
            player.GetModPlayer<DrakSolzPlayer>().BossSoulTicks += 85;
            return true;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.XItem>().FromPlayer;
            return (player.whoAmI == fromPlayer);
        }
    }
}