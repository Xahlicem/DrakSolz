using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollFireStorm : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Firestorm");
            Tooltip.SetDefault("Pyromancy used by Flame Warmages, enhanced to conjure multiple pillars of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.magic = false;
            item.damage = 70;
            item.useTime = 50;
            item.useAnimation = 50;
            item.rare = ItemRarityID.Cyan;
            item.mana = 30;
            item.knockBack = 0f;
			item.crit = 4;
            item.shootSpeed = 0f;
            item.value = Item.sellPrice(0, 12, 50, 0);
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.FlameStormProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            position = new Vector2(player.Center.X, player.Center.Y);
            speedY = 40;
            knockBack = 0f;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            player.velocity.X = 0;
            player.jump = 0;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.PyroScroll>());
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.IT>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}