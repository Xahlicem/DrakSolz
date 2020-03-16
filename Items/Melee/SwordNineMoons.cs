using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class SwordNineMoons : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sword of the Nine Moons");
            Tooltip.SetDefault("It's just a phase, it'll pass it'll pass" +
                "\nHeals life on hit");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.CopperShortsword);
            item.damage = 40;
            item.knockBack = 9f;
            item.reuseDelay = 30;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 3;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.autoReuse = false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }

        public override bool UseItem(Player player) {
            if (player.velocity.X != 0 && player.velocity.X < 7 && player.velocity.X > -7){
            player.velocity.X = 6 * player.direction;}
            if (player.velocity.X <= -7 || player.velocity.X >= 7){
            player.velocity.X = 10 * player.direction;}
            if (player.velocity.Y >= 0.5f){
            player.velocity.Y -= 0.5f;}
            if (player.velocity.Y <= -0.5f){
            player.velocity.X += 0.5f;}
            return base.UseItem(player);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.Bleeding, 180);
            player.velocity.X = 0;
            
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            modPlayer.DecreaseHollow(240);
            int amount = (int)(damage * 0.02);
            player.statLife += (1 + amount);
            player.HealEffect(1 + amount);
        
        }
    }
}