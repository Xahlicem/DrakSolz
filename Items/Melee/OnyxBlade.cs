using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class OnyxBlade : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Onyx Blade");
            Tooltip.SetDefault("Thrives off of its wielder's mortality, inflicts shadow flame.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BreakerBlade);
            item.damage = 95;
            item.knockBack = 7.5f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.value = Item.buyPrice(1, 50, 0, 0);
            item.autoReuse = true;
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(0, 0);
        }

        public override bool UseItem(Player player) {
            item.damage = 95 + (int)((player.statLifeMax2 - player.statLife) * 0.2f);
            return base.UseItem(player);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.ShadowFlame, 180);
        }
    }
}