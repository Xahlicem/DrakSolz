using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.SoulBlades {
    public class ScrollSoulBlades2 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Blades");
            Tooltip.SetDefault("Sorcery that projects blades from above toward your target.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(mod.ItemType("ScrollSoulBlades1"));
            item.damage = 90;
            item.useTime = 10;
            item.useAnimation = 10;
            item.mana += 2;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ScrollSoulBlades1"), 1);
            recipe.AddIngredient(mod.ItemType("Soul"), 30000);
            recipe.AddTile(mod.TileType<Items.Misc.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y - 50, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}