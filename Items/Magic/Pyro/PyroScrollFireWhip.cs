using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollFireWhip : SoulItem {
        public PyroScrollFireWhip() : base(30000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Whip");
            Tooltip.SetDefault("Pyromancy that conjures a constant bursting flame from your hand.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 18;
            item.useTime = 5;
            item.useAnimation = 5;
            item.mana = 5;
            item.knockBack = 1.25f;
			item.crit = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.FireWhipProj>();
            item.shootSpeed = 3.25f;
            item.autoReuse = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireSurge>());
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFlameWeapon>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}