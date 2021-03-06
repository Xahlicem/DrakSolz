using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class KeroKhi : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Kero Khi");
            Tooltip.SetDefault("Edgy Incarnate.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.damage = 2500;
            item.knockBack = 10f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.value = Item.sellPrice(0, 75, 0, 0);
            item.scale *= 1.3f;
        }
                public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(1) == 0)
			{
				//Emit dusts when swing the sword
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
			}
		}
                public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Melee.Khi>());
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.ArtoriasSoul>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}