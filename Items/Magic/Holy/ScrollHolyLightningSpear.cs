using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolyLightningSpear : SoulItem {
        public ScrollHolyLightningSpear() : base(1500) { }


        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lightning Spear");
            Tooltip.SetDefault("Miracle that sends a spear of lightning piercing through the air." +
                "\n Fires a more powerful spear at higher mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 1;
            item.magic = false;
            item.damage = 25;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 8;
            item.knockBack = 4.0f;
            item.shootSpeed = 14.0f;
            item.value = Item.buyPrice(0, 1, 80, 0);
            item.autoReuse = false;
            item.shoot = mod.ProjectileType<Projectiles.LightningSpearProj>();
            item.summon = true;
        }

        public override void AddRecipes() {
        ModRecipe recipe = new SoulRecipe(mod, this);
        recipe.AddIngredient(mod.ItemType<Items.Misc.ScrollHoly>());
        recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
        recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;

            if (player.statMana >= (((player.statManaMax2) * 0.5) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 1.0f;
                Main.projectile[pro].penetrate = 2;
                Main.projectile[pro].velocity *= 1.0f;
                Main.projectile[pro].timeLeft = 60;
                Main.projectile[pro].knockBack *= 1.0f;

            } else {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.8f;
                Main.projectile[pro].penetrate = 1;
                Main.projectile[pro].velocity *= 0.8f;
                Main.projectile[pro].timeLeft = 50;
                Main.projectile[pro].knockBack *= 0.8f;
            }
            return false;
        }
    }
}