using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class FlameFan : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Flame Fan");
            Tooltip.SetDefault("Pyromancy that conjures a fan of flames.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 1;
            item.damage = 72;
            item.useTime = 25;
            item.useAnimation = 25;
            item.mana = 15;
            item.knockBack = 2.5f;
            item.shootSpeed = 2.0f;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.shoot = 85;
            item.autoReuse = true;
        }


        //public override void AddRecipes() {
            //ModRecipe recipe = new SoulRecipe(mod, this);
            //recipe.AddIngredient(mod.ItemType<Items.Misc.PyroScroll>());
            //recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            //recipe.AddRecipe();
        //}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(30);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.8f; // Watch out for dividing by 0 if there is only 1 projectile.
				int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].tileCollide = false;
			}
			return false;
        }
public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(1) == 0)
			{
				//Emit dusts when swing the sword
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
			}
		}

    }
}