using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.MagnetSphere {
    public class FulminatingSphere : ModItem {
        public override string Texture { get { return "Terraria/Item_1266"; } }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fulminating Sphere");
            Tooltip.SetDefault("Summons a fulminating sphere to attack enemies.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.MagnetSphere);
            item.useStyle = 5;
            item.damage = 100;
            item.mana = 20;
            item.knockBack = 7f;
            item.shootSpeed = 0.2f;
            item.value = Item.buyPrice(0, 80, 0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].frame = 1;
            Main.projectile[pro].scale *= 1.5f;
            return false;
        }
        public class FulminatingSphereGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(5) == 0 && NPC.downedAncientCultist) {
                    if (npc.type == NPCID.Eyezor) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.MagnetSphere.FulminatingSphere>(), 1);
                    }
                }
            }
        }
    }
}