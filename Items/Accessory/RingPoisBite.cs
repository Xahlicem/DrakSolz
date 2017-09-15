﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingPoisBite : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Poisonbite Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+Immunity to Poison Effects");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Venom] = true;
        }
    }
}