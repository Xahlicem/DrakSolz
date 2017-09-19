﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class PlantSoul : ModItem {
        public const int PLACE = 1 << 11;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Verdant Soul");
            Tooltip.SetDefault("Soul of Plantera" +
                "\n+22500 Souls when consumed.");
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
            item.rare = 7;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.ManaEffect(22500);
            player.GetModPlayer<DrakSolzPlayer>().BossSoulTicks += 115;
            return true;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.XItem>().FromPlayer;
            return (player.whoAmI == fromPlayer);
        }
    }
}