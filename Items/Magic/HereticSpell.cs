using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class HereticSpell : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Heretic's Spellbook");
            Tooltip.SetDefault("Staff used by Mechanysts, conjures a howling tornado.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 1;
            item.scale *= 1;
            item.magic = true;
            item.noMelee = true;
            item.damage = 800;
            item.useTime = 60;
            item.useAnimation = 60;
            item.rare = 4;
            item.mana = 40;
            item.knockBack = 8f;
            item.shootSpeed = 0f;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType<Projectiles.HereticProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.statMana >= item.buffTime * player.manaCost) {
                damage *= 2;
                player.statMana -= (int)(item.buffTime * player.manaCost);
                item.mana = item.buffTime;
                int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 0, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].timeLeft = 120;
                return false;
            }
            item.mana = item.buffTime;
            return false;
        }
        public class MechanystStaffGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == mod.NPCType<NPCs.Enemy.Endgame.Desert.Starless>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Magic.MechanystStaff>(), 1);
                    }
                }
            }
        }
    }
}