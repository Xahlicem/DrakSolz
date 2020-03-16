using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class RejuvenatorSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rejuvenator's Sword");
            Tooltip.SetDefault("Immortality is within your grasp" +
                "\nHeals life on hit");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.CobaltSword);
            item.damage = 200;
            item.knockBack = 10f;
            item.useTime = 28;
            item.useAnimation = 28;
            item.rare = ItemRarityID.Cyan;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            modPlayer.DecreaseHollow(300);
            int amount = (int)(damage * 0.01);
            player.statLife += (amount);
            player.HealEffect(amount);
        
        }
                public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.MoonSoul>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}