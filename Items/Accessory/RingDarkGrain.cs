﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingDarkGrain : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Darkwood Grain Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+Reflexes");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.dash += 1;
            player.runAcceleration += 1;
            player.ignoreWater = true;
            player.buffImmune[BuffID.Slow] = true;
            player.maxFallSpeed += 10;
            player.fallStart = 0;
            player.jumpSpeedBoost += 3;
            player.noFallDmg = true;
            int i = player.FindBuffIndex(mod.BuffType<Buffs.BoneWheelMount>());
            if (player.velocity.Y != 0 )
            player.fullRotation += player.velocity.X * 0.025f;
            else player.fullRotation = 0f;

        }
    }
}