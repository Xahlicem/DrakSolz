using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ScrollSpear : SoulItem {
        public ScrollSpear() : base(100000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Spear");
            Tooltip.SetDefault("A piecing spear of magic.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 100;
            item.useTime = 25;
            item.useAnimation = 25;
            item.mana = 15;
            item.knockBack = 2f;
            item.shootSpeed = 30.0f;
            item.rare = 9;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.Magic.SoulSpearProj1>();
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Magic.SoulArrow.ScrollSoulDart>());
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}