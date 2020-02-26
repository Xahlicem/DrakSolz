using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class IE : PyromancyItem {
        public IE() : base(0) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Immolation Ember");
            Tooltip.SetDefault("Staff used by Flame Warmages, conjures a great pillar of fire.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.magic = false;
            item.damage = 100;
            item.useTime = 40;
            item.useAnimation = 40;
            item.rare = ItemRarityID.Red;
            item.mana = 30;
            item.knockBack = 12.5f;
			item.crit = 4;
            item.shootSpeed = 0f;
            item.value = Item.sellPrice(0, 35, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.FlameMageProj2>();
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
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.IT>());
            recipe.AddIngredient(ModContent.ItemType<Items.Souls.GolemSoul>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}