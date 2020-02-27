using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollCombustion : SoulItem {
        public PyroScrollCombustion() : base(100) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Combustion");
            Tooltip.SetDefault("Pyromancy that conjures a bursting flame from your hand.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 4;
            item.knockBack = 2.5f;
			item.crit = 4;
            item.shootSpeed = 1.0f;
            item.value = Item.sellPrice(0, 0, 7, 50);
            item.shoot = ModContent.ProjectileType<Projectiles.FireProj>();
        }


        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.PyroScroll>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            return false;
        }
    }
}