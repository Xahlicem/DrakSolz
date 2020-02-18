using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class GravelordSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ravelord Sword");
            Tooltip.SetDefault("Greatsword used by Ravelord Nito.");
        }
        public override void SetDefaults() {
            item.useStyle = 1;
            item.scale *= 1.2f;
            item.melee = true;
            item.damage = 105;
            item.useTime = 30;
            item.useAnimation = 30;
            item.rare = ItemRarityID.Yellow;
            item.knockBack = 9f;
            item.shootSpeed = 0.01f;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.GravelordProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            damage *= 2;
            float direction = Main.mouseX - Main.screenWidth / 2;
            int pro = Projectile.NewProjectile((player.Center.X + (100 * (direction >= 0 ? 1 : -1))), player.Center.Y, 1 * (direction >= 0 ? 1 : -1), 0, type, (int)(damage * 0.60f), 0, player.whoAmI, player.Center.Y);
            return false;

        }
    }
}