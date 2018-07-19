﻿using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingCloranthy : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ring of Cloranthy");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+30% Max Move Speed" +
                "\n+15% Melee Speed");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.maxRunSpeed += 0.30f;
            player.moveSpeed += 0.15f;
            player.meleeSpeed += 0.15f;
        }
    }
}