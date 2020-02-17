using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MoonGS : ModItem {

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

        public override bool CanUseItem(Player player) {
            if (item.mana == 0) item.mana = item.alpha;
            else item.alpha = item.mana;
            item.buffTime = item.mana;
            item.mana = 0;
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.statMana >= item.buffTime * player.manaCost) {
                damage *= 2;
                player.statMana -= (int)(item.buffTime * player.manaCost);
                item.mana = item.buffTime;
                return true;
            }
            item.mana = item.buffTime;
            return false;
        }
    }
}