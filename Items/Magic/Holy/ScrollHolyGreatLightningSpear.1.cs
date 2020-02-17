using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolyGreatLightningSpear : SoulItem {
        public ScrollHolyGreatLightningSpear() : base(35000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Great Lightning Spear");
            Tooltip.SetDefault("Miracle that sends a spear of lightning piercing through the sky." +
                "\n Fires a more powerful spear at higher mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 1;
            item.magic = false;
            item.damage = 60;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 25;
            item.useAnimation = 25;
            item.mana = 10;
            item.knockBack = 5.0f;
            item.shootSpeed = 17.0f;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.GreatLightningSpearProj>();
            item.summon = true;
        }

        public override void AddRecipes() {
        ModRecipe recipe = new SoulRecipe(mod, this);
        recipe.AddIngredient(ModContent.ItemType<Items.Magic.Holy.ScrollHolyLightningSpear>());
        recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
        recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;

            if (player.statMana >= (((player.statManaMax2) * 0.66) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 1.0f;
                Main.projectile[pro].penetrate = 3;
                Main.projectile[pro].velocity *= 1.0f;
                Main.projectile[pro].timeLeft = 60;
                Main.projectile[pro].knockBack *= 1.0f;

            }
            else if (player.statMana >= (((player.statManaMax2) * 0.33) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.8f;
                Main.projectile[pro].penetrate = 2;
                Main.projectile[pro].velocity *= 0.9f;
                Main.projectile[pro].timeLeft = 55;
                Main.projectile[pro].knockBack *= 0.9f;
            }
            else {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 0.6f;
                Main.projectile[pro].penetrate = 1;
                Main.projectile[pro].velocity *= 0.8f;
                Main.projectile[pro].timeLeft = 50;
                Main.projectile[pro].knockBack *= 0.8f;
            }
            return false;
        }
    }
}