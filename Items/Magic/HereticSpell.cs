using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class HereticSpell : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Heretic's Spellbook");
            Tooltip.SetDefault("Staff used by Heretics, conjures a vortex that fires out spectral bolts.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 5;
            item.scale *= 1;
            item.magic = true;
            item.noMelee = true;
            item.damage = 50;
            item.useTime = 40;
            item.useAnimation = 40;
            item.rare = ItemRarityID.LightRed;
            item.mana = 24;
            item.knockBack = 6f;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.shootSpeed = 0f;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Projectiles.HereticProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].hostile = false;
            Main.projectile[pro].friendly = false;
            Main.projectile[pro].ai[1] = 1;
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.RetSoul>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}