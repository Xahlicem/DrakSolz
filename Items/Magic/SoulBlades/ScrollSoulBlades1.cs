using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.SoulBlades {
    public class ScrollSoulBlades1 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Blades");
            Tooltip.SetDefault("Sorcery that projects blades from above toward your target.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(mod.ItemType("ScrollSoulBlades"));
            item.damage = 60;
            item.useTime = 16;
            item.useAnimation = 16;
            item.mana += 2;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ScrollSoulBlades"), 1);
            recipe.AddIngredient(mod.ItemType("Soul"), 10000);
            recipe.AddTile(mod.TileType("FirelinkShrine2"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.DirtBlock, 1);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
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