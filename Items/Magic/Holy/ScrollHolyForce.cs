using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolyForce : SoulItem {
        public ScrollHolyForce() : base(100) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Force");
            Tooltip.SetDefault("Miracle that emits great force; pushing foes away.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 10;
            item.useTime = 40;
            item.useAnimation = 40;
            item.mana = 5;
            item.knockBack = 12f;
            item.shootSpeed = 3.0f;
            item.value = Item.buyPrice(0, 0, 20, 0);
            item.shoot = mod.ProjectileType<Projectiles.ForceProj>();
            item.summon = true;
            item.magic = false;
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
                Main.projectile[pro].scale *= 1.4f;
                Main.projectile[pro].penetrate = 1;
                Main.projectile[pro].velocity *= 1.4f;
                Main.projectile[pro].timeLeft = 120;
                Main.projectile[pro].knockBack *= 1.25f;

            } else {
                Main.projectile[pro].damage -= 2;
                Main.projectile[pro].scale *= 1.0f;
                Main.projectile[pro].penetrate = 1;
                Main.projectile[pro].velocity *= 1.0f;
                Main.projectile[pro].timeLeft = 120;
                Main.projectile[pro].knockBack *= 1.0f;
            }
            return false;
        }
    }
}