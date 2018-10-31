using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ScrollSpear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Spear");
            Tooltip.SetDefault("A piecing spear of magic.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 900;
            item.useTime = 25;
            item.useAnimation = 25;
            item.mana = 25;
            item.knockBack = 2f;
            item.shootSpeed = 30.0f;
            item.value = Item.buyPrice(0, 80, 0, 0);
            item.rare = 9;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.Magic.SoulSpearProj1>();
        }
    }
}