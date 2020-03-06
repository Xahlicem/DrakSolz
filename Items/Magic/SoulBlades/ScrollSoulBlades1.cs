using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.SoulBlades {
    public class ScrollSoulBlades1 : SoulItem {
        public ScrollSoulBlades1() : base(15000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Blades");
            Tooltip.SetDefault("Sorcery that projects blades from above toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades>());
            item.damage = 44;
            item.useTime = 16;
            item.useAnimation = 16;
            item.value = Item.sellPrice(0, 1, 25, 0);
            item.mana += 3;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y - 50, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            return false;
        }
    }
}