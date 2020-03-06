using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ADagger : MagicWeapon {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Aquamarine Dagger");
            Tooltip.SetDefault("A dagger fitted with aquamarine crystal.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 3;
            item.scale *= 1f;
            item.magic = true;
            item.damage = 70;
            item.useTime = 18;
            item.useAnimation = 18;
            item.rare = 9;
            item.mana = 8;
            item.knockBack = 1.5f;
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 12, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.ADaggerProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            damage *= 2;
            speedY = 0;
            speedX = player.direction * item.shootSpeed;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.CthulhunEmbryo>());
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulArrowGreat>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}