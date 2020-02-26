using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollBlackFlame : PyromancyItem {
        public PyroScrollBlackFlame() : base(40000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Flame");
            Tooltip.SetDefault("Pyromancy that conjures a constant bursting black flame from your hand.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 52;
            item.useTime = 10;
            item.useAnimation = 10;
            item.mana = 6;
            item.knockBack = 3.0f;
			item.crit = 4;
            item.shootSpeed = 4.0f;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.FireProj3>();
            item.autoReuse = true;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new PyromancyRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireSurge>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}