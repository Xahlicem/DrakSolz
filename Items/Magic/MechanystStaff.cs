using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MechanystStaff : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mechanyst Staff");
            Tooltip.SetDefault("Staff used by Mechanysts, conjures a howling tornado.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.scale *= 0.85f;
            item.magic = true;
            item.noMelee = true;
            item.damage = 800;
            item.useTime = 55;
            item.useAnimation = 55;
            item.rare = 4;
            item.mana = 90;
            item.knockBack = 8f;
            item.shootSpeed = 0f;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.autoReuse = false;
            item.shoot = ProjectileID.SandnadoFriendly;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].timeLeft = 120;
            return false;
        }
        public class MechanystStaffGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Desert.Starless>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.MechanystStaff>(), 1);
                    }
                }
            }
        }
    }
}