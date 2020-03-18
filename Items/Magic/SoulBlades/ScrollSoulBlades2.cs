using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.SoulBlades {
    public class ScrollSoulBlades2 : SoulItem {
        public ScrollSoulBlades2() : base(75000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Blades");
            Tooltip.SetDefault("Sorcery that projects blades from above toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades1>());
            item.damage = 66;
            item.useTime = 10;
            item.useAnimation = 10;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.mana += 2;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades1>());
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int num = Main.rand.Next(40);
            int pro = Projectile.NewProjectile(position.X - (25 * player.direction), position.Y - num, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            return false;
        }
    }
}