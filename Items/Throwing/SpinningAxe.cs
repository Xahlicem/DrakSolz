using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing
{
	public class SpinningAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Spinning Axe");
			Tooltip.SetDefault("???");
		}

		public override void SetDefaults()
		{
			item.damage = 1550;
			item.thrown = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
            item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.SpinningAxeProj>();
			item.shootSpeed = 12f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
                position += muzzleOffset;
            }
            return true;
        }


        public class SpinningAxeGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Hallow.SettingSun>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Throwing.SpinningAxe>(), 1);
                    }
                }
            }
        }
    }
}