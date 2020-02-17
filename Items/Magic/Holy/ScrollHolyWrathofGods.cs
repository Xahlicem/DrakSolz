using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolyWrathofGods : SoulItem {
        public ScrollHolyWrathofGods() : base(250000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wrath of the Gods");
            Tooltip.SetDefault("Miracle that emits godly force; damaging and pushing foes away.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 4;
            item.noUseGraphic = true;
            item.damage = 150;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 25;
            item.knockBack = 16f;
            item.shootSpeed = 20.0f;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.ForceProj>();
            item.summon = true;
            item.magic = false;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Holy.ScrollHolyForce>());
            recipe.AddIngredient(ModContent.ItemType<Items.Banners.SilverKnightBanner>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {

            float numberProjectiles = 20; // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(180);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 1f;
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].frame = 1;
                if (player.statMana >= (((player.statManaMax2) * 0.5) - (item.mana * player.manaCost))) {
                    Main.projectile[pro].damage *= 1;
                    Main.projectile[pro].scale *= 1.0f;
                    Main.projectile[pro].penetrate = -1;
                    Main.projectile[pro].velocity *= 5.25f;
                    Main.projectile[pro].timeLeft = 3;
                    Main.projectile[pro].knockBack *= 1.0f;
                    Main.projectile[pro].tileCollide = false;

                } else {
                    Main.projectile[pro].damage -= 5;
                    Main.projectile[pro].scale *= 1.0f;
                    Main.projectile[pro].penetrate = -1;
                    Main.projectile[pro].velocity *= 3.5f;
                    Main.projectile[pro].timeLeft = 3;
                    Main.projectile[pro].knockBack *= 0.75f;
                    Main.projectile[pro].tileCollide = false;
                }
            }
            return false;
        }
    }
}