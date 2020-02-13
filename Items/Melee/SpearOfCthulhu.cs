using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class SpearOfCthulhu : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spear Of Cthulhu");
            Tooltip.SetDefault("A trident that has been consumed and malformed by a Cthulhun Embryo.");
        }

        public override void SetDefaults() {
            item.damage = 55;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 44;
            item.shootSpeed = 4.4f;
            item.knockBack = 3f;
            item.width = 28;
            item.height = 28;
            item.scale = 1f;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<Projectiles.SpearOfCthulhuProj>();
            item.value = 300000;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.CthulhunEmbryo>());
            recipe.AddIngredient(ItemID.Trident);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}