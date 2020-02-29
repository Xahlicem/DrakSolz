using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class IT : MagicWeapon {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Immolation Tinder");
            Tooltip.SetDefault("Staff used by Flame Warmages, conjures a pillar of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.scale *= 0.85f;
            item.magic = false;
            item.damage = 70;
            item.useTime = 55;
            item.useAnimation = 55;
            item.rare = ItemRarityID.Cyan;
            item.mana = 25;
            item.knockBack = 10f;
			item.crit = 4;
            item.shootSpeed = 0f;
            item.value = Item.sellPrice(0, 12, 50, 0);
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.FlameMageProj1>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            position = new Vector2(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y);
            speedY = 40;
            damage = (int)(damage * 0.7f);
            knockBack = 0f;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 120);
        }
    }
}