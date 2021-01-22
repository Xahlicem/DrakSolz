using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    public class D6L : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Loaded Dice");
            Tooltip.SetDefault("Your god won't save you now.");
        }

        public override void SetDefaults() {
            item.damage = 18;
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
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
            item.consumable = true;
            item.autoReuse = true;
            item.maxStack = 10;
            item.shoot = ModContent.ProjectileType<Projectiles.D6LProj>();
            item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            damage = 18;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public class D6LGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(5) == 0) {
                    if (npc.type == NPCID.Mimic) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Throwing.D6L>(), (Main.rand.Next(5) +1 ));
                    }
                }
            }
        }
    }
}