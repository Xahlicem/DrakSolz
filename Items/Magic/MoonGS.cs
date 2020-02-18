using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MoonGS : MagicWeapon {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Greatsword");
            Tooltip.SetDefault("Shoots a wave!");
        }

        public override void SetDefaults() {
            item.damage = 250;
            item.magic = true;
            item.mana = 20;
            item.width = 90;
            item.height = 90;
            item.useTime = 25;
            item.value = Item.buyPrice(0, 60, 0, 0);
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<Projectiles.MGSProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            damage *= 2;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}