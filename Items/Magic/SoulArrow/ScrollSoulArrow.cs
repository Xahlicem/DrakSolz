using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.SoulArrow {
    public class ScrollSoulArrow : SoulItem {
        public ScrollSoulArrow() : base(1000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Arrow");
            Tooltip.SetDefault("Sorcery that projects a soul arrow toward your target.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 5;
            item.knockBack = 2f;
            item.shootSpeed = 20.0f;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.SoulProj>();
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Scroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            return false;
        }
    }
}