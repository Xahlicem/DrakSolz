using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Pyro {
    public class DemonsScar : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Demon's Scar");
            Tooltip.SetDefault("Living flame wielding in one's hand, sets enemies on fire. 10% chance to ignite self for 2 seconds.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.melee = false;
            item.useStyle = 1;
            item.damage = 132;
            item.useTime = 18;
            item.useAnimation = 18;
            item.mana = 4;
            item.crit = 8;
            item.knockBack = 5.0f;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 120);
            if (Main.rand.Next(10) == 0) {
                player.AddBuff(BuffID.OnFire, 120);
            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Pyro.PyroScrollFlameWeapon>());
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}