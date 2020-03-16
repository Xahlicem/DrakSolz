using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class GibbetSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gibbet Dagger");
            Tooltip.SetDefault("Dagger of peculiar workmenship, seems incredibly sharp");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BladedGlove);
            item.damage = 60;
            if(Main.hardMode){
            item.damage = 100;
            }
            if(NPC.downedPlantBoss){
            item.damage = 160;
            }
            if(NPC.downedMoonlord){
            item.damage = 240;
            }
            item.crit = 8;
            item.knockBack = 3f;
            item.useTime = 34;
            item.useAnimation = 34;
            item.scale *= 0.7f;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.ShadowFlame, 180);
        }
        
                public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.BeeSoul>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}