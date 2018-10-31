using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class LightningArrow : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lightning Arrow");
            Tooltip.SetDefault("Miracle that conjures a bow with arrows made of lightning." +
                "\n Fires a more powerful arrow at full mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.useStyle = 5;
            item.damage = 550;
            item.noMelee = true;
            item.useTime = 18;
            item.useAnimation = 18;
            item.mana = 10;
            item.knockBack = 3.0f;
            item.shootSpeed = 20.0f;
            item.value = Item.buyPrice(1, 50, 0, 0);
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.LightningArrowProj>();
            item.summon = true;
            item.magic = false;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-14, 0);
}

        //public override void AddRecipes() {
            //ModRecipe recipe = new SoulRecipe(mod, this);
            //recipe.AddIngredient(mod.ItemType<Items.Misc.PyroScroll>());
            //recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            //recipe.AddRecipe();
        //}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            
            if (player.statMana >= ((player.statManaMax2) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 2;
                Main.projectile[pro].scale *= 1.5f;
                Main.projectile[pro].penetrate = 6;
                Main.projectile[pro].velocity *= 1.5f;
                Main.projectile[pro].timeLeft = 45;
                Main.projectile[pro].light = 2;
                }
                else
                {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].scale *= 1;
                Main.projectile[pro].penetrate = 4;
                Main.projectile[pro].velocity *= 1;
                Main.projectile[pro].timeLeft = 30;
                Main.projectile[pro].light = 0.5f;
                }

            return false;
        }
         
    
public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(1) == 0)
			{
				//Emit dusts when swing the sword
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AmberBolt);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
			}
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Magic.Holy.ScrollHolySunlightSpear>());
            recipe.AddIngredient(mod.ItemType<Items.Ranged.DragonslayerGreatbow>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
    }
}