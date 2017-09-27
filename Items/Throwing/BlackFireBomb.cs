﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    class BlackFireBomb : ModItem {

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Black Fire Bomb");
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.damage = 130;
            item.thrown = true;
            item.shootSpeed = 13f;
            item.width = 28;
            item.height = 28;
            item.maxStack = 999;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.rare = 6;
            item.shoot = mod.ProjectileType<Projectiles.BlackFireBombProj>();
        }
    }
}