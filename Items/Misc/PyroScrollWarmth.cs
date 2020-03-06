using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Misc {
    public class PyroScrollWarmth : SoulItem {
        public PyroScrollWarmth() : base(30000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Warmth");
            Tooltip.SetDefault("Produces a warm flame that heals nearby allies.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 5;
            item.damage = 0;
            item.mana = 40;
            item.knockBack = 7f;
            item.shootSpeed = 0;
            item.shoot = ModContent.ProjectileType<Projectiles.WarmthProj>();
            item.value = Item.sellPrice(0, 10, 0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            player.AddBuff(ModContent.BuffType<Buffs.ScrollMana>(), 14400);
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, speedX, speedY, type, 0, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            Main.projectile[pro].scale *= 1.5f;
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.PyroScroll>());
            recipe.AddIngredient(ModContent.ItemType<Tiles.FirelinkShrine>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}