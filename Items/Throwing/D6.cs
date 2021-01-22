using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    public class D6 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("6-Sided Dice");
            Tooltip.SetDefault("Better pray to RNGeesus. 3x Multiplier.");
        }

        public override void SetDefaults() {
            item.damage = 6;
            item.thrown = true;
            item.lavaWet = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
            item.consumable = true;
            item.autoReuse = false;
            item.maxStack = 10;
            item.shoot = ModContent.ProjectileType<Projectiles.D6Proj>();
            item.shootSpeed = 6f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int d = Main.rand.Next(6) + 1;
            damage = (int)(d * 3);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public class D6GlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(10) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.HollowDog>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Throwing.D6>(), 1);
                    }
                }
            }
        }
    }
}