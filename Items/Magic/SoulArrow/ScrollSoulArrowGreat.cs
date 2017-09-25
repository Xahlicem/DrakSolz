using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.SoulArrow {
    public class ScrollSoulArrowGreat : SoulItem {
        public ScrollSoulArrowGreat() : base(5000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Great Soul Arrow");
            Tooltip.SetDefault("Sorcery that projects a soul arrow toward your target.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(mod.ItemType<Items.Magic.SoulArrow.ScrollSoulArrow>());
            item.noUseGraphic = true;
            item.damage = 30;
            item.mana = 7;
            item.knockBack = 2.5f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(mod.ItemType<Items.Magic.SoulArrow.ScrollSoulArrow>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 2;
            return false;
        }
    }
}