using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class RitualSpearFragment : SoulItem {
        public RitualSpearFragment() : base(8000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ritual Spear Fragment");
            Tooltip.SetDefault("Miracle that conjurs holy spears from beneath to rise to the skies. Deals x2 damage when above 50% mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 4;
            item.noUseGraphic = true;
            item.damage = 13;
            item.useTime = 35;
            item.useAnimation = 35;
            item.mana = 14;
            item.knockBack = 2.5f;
            item.shootSpeed = 8.0f;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.HolySpearProj>();
            item.summon = true;
            item.magic = false;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.ScrollHoly>());
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            float direction = Main.mouseX - Main.screenWidth / 2;
            int pro = Projectile.NewProjectile((player.Center.X + (60 * (direction >= 0 ? 1 : -1))), player.Center.Y + 20, 1 * (direction >= 0 ? 1 : -1), 0, type, (int) (damage * 0.60f), 0, player.whoAmI, player.Center.Y);
            Main.projectile[pro].frame = 1;
            if (player.statMana >= (((player.statManaMax2) * 0.5) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 2;
                Main.projectile[pro].knockBack *= 2;
            } else {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].ai[1] += 3;
            }
            return false;
        }
    }
}