using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.MagnetSphere {
    public class ElectricSphere : ModItem {
        public override string Texture { get { return "Terraria/Item_1266"; } }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Electric Sphere");
            Tooltip.SetDefault("Summons an electric sphere to attack enemies.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.MagnetSphere);
            item.useStyle = 5;
            item.damage = 15;
            item.useTime = 60;
            item.useAnimation = 60;
            item.mana = 10;
            item.knockBack = 4f;
            item.shootSpeed = 10.0f;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            Main.projectile[pro].scale *= 0.5f;
            return false;
        }
        public class ElectricSphereGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(30) == 0) {
                    if (npc.type == NPCID.GoblinSorcerer) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.MagnetSphere.ElectricSphere>(), 1);
                    }
                }
            }
        }
    }
}