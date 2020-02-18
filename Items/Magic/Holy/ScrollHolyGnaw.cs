using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class ScrollHolyGnaw : SoulItem {
        public ScrollHolyGnaw() : base(10000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gnaw");
            Tooltip.SetDefault("Summons insect swarm to feast on foes." +
                "\n Unleashes more insects at higher mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 1;
            item.magic = false;
            item.damage = 30;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 18;
            item.knockBack = 2.0f;
            item.shootSpeed = 3.0f;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.autoReuse = false;
            item.shoot = 307;
            item.summon = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.ScrollHoly>());
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.EaterSoul>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.statMana >= (((player.statManaMax2) * 0.5) - (item.mana * player.manaCost))) {
                float numberProjectiles = 3;
                float rotation = MathHelper.ToRadians(20);
                position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
                for (int i = 0; i < numberProjectiles; i++) {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.8f; // Watch out for dividing by 0 if there is only 1 projectile.
                    int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    Main.projectile[pro].timeLeft = 120;
                }

            } else {
                float numberProjectiles = 2;
                float rotation = MathHelper.ToRadians(20);
                position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
                for (int i = 0; i < numberProjectiles; i++) {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.8f; // Watch out for dividing by 0 if there is only 1 projectile.
                    int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    Main.projectile[pro].timeLeft = 120;
                }
            }
            return false;
        }
    }
}