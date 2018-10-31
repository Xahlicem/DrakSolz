using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class IE : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Immolation Ember");
            Tooltip.SetDefault("Staff used by Flame Warmages, conjures a great pillar of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.magic = true;
            item.damage = 100;
            item.useTime = 40;
            item.useAnimation = 40;
            item.rare = 10;
            item.mana = 20;
            item.knockBack = 12.5f;
            item.shootSpeed = 0f;
            item.value = Item.buyPrice(0, 70, 0, 0);
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.Magic.FlameMageProj2>();
        }

        public override bool CanUseItem(Player player) {
            if (item.mana == 0) item.mana = item.alpha;
            else item.alpha = item.mana;
            item.buffTime = item.mana;
            item.mana = 0;
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.statMana >= item.buffTime * player.manaCost) {
                damage *= 2;
                player.statMana -= (int)(item.buffTime * player.manaCost);
                item.mana = item.buffTime;
                int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 40, type, (int)(damage * 0.65f), 0, player.whoAmI);
                return false;
            }
            item.mana = item.buffTime;
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

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add Onfire buff to the NPC for 1 second
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 240);		
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Magic.IT>());
            recipe.AddIngredient(mod.ItemType<Items.Souls.GolemSoul>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}