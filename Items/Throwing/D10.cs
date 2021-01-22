using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    public class D10 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("10-Sided Dice");
            Tooltip.SetDefault("Better pray to RNGeesus. 6x Multiplier.");
        }

        public override void SetDefaults() {
            item.damage = 10;
            item.thrown = true;
            item.lavaWet = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 1, 10, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
            item.consumable = true;
            item.autoReuse = true;
            item.maxStack = 10;
            item.shoot = ModContent.ProjectileType<Projectiles.D10Proj>();
            item.shootSpeed = 10f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int d = Main.rand.Next(10) + 1;
            damage = (int)(d * 6);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public class D10GlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(5) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.HardMode.Cthulhun.CthulhunRoyalty>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Throwing.D10>(), 1);
                    }
                }
            }
        }
    }
}