using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class IT2 : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Immolation Tinder");
            Tooltip.SetDefault("Staff used by Flame Warmages, conjures a great pillar of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.magic = true;
            item.damage = 80;
            item.useTime = 55;
            item.useAnimation = 55;
            item.rare = 10;
            item.mana = 20;
            item.knockBack = 18f;
            item.shootSpeed = 0f;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType<Projectiles.Magic.FlameMageProj1>();
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
                int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 40, type, (int)(damage * 0.5f), 0, player.whoAmI);
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
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add Onfire buff to the NPC for 1 second
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 120);		
}
    }
}