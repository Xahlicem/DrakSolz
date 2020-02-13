using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing
{
	public class HighTemplarHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("High Templar Hammer");
			Tooltip.SetDefault("???");
		}

		public override void SetDefaults()
		{
			item.damage = 1800;
			item.thrown = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 9;
            item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.HighTemplarHammerproj>();
			item.shootSpeed = 20f;
		}


        public class HighTemplarHammerGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Dungeon.HighTemplar>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Throwing.HighTemplarHammer>(), 1);
                    }
                }
            }
        }
    }
}