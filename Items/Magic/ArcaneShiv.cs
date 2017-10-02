using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ArcaneShiv : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arcane Shiv");
            Tooltip.SetDefault("Leaves an illusory trail that damages foes.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.MagicDagger);
            item.scale *= 1f;
            item.magic = true;
            item.damage = 65;
            item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 9;
            item.mana = 10;
            item.knockBack = 3.5f;
            item.shootSpeed = 5f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.Magic.ArcaneShivProj>();
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicDagger);
            recipe.AddIngredient(mod.ItemType<Items.Souls.LunaticSoul>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}