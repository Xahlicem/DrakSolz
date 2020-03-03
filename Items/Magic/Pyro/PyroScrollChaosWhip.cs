using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollChaosWhip : SoulItem {
        public PyroScrollChaosWhip() : base(100000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Whip");
            Tooltip.SetDefault("Pyromancy that conjures a constant bursting flame from your hand.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 38;
            item.useTime = 4;
            item.useAnimation = 4;
            item.mana = 6;
            item.knockBack = 1.25f;
			item.crit = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.FireWhipProj>();
            item.shootSpeed = 5.00f;
            item.autoReuse = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireWhip>());
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFlameWeapon>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}