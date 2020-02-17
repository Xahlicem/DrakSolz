using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollBlackFlame : SoulItem {
        public PyroScrollBlackFlame() : base(40000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Flame");
            Tooltip.SetDefault("Pyromancy that conjures a constant bursting black flame from your hand.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 52;
            item.useTime = 10;
            item.useAnimation = 10;
            item.mana = 6;
            item.knockBack = 3.0f;
            item.shootSpeed = 4.0f;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.FireProj3>();
            item.autoReuse = true;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireSurge>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}