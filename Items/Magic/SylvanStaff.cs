using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class SylvanStaff : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sylvan Staff");
            Tooltip.SetDefault("Staff used by Sylvan Casters.");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 5;
            item.magic = true;
            item.noMelee = true;
            item.damage = 900;
            item.useTime = 20;
            item.useAnimation = 20;
            item.rare = 4;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.mana = 18;
            item.knockBack = 8f;
            item.autoReuse = true;
            item.shoot = ProjectileID.CrystalLeafShot;
            item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 75f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
                position += muzzleOffset;
            }

            int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].penetrate = 5;
            Main.projectile[pro].scale *= 2;
            return false;
        }
        public class SylvanStaffGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Jungle.SylvanCaster>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.SylvanStaff>(), 1);
                    }
                }
            }
        }
    }
}