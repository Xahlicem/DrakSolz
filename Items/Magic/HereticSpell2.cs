using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class HereticSpell2 : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Heretic's Master Spellbook");
            Tooltip.SetDefault("Book used by Heretics, conjures a vortex that fires out many spectral bolts.");
        }
        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.StardustDragonStaff);
            item.useStyle = 5;
            item.scale *= 1;
            item.magic = true;
            item.noMelee = true;
            item.damage = 820;
            item.useTime = 40;
            item.useAnimation = 40;
            item.rare = ItemRarityID.LightRed;
            item.mana = 28;
            item.knockBack = 5f;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.shootSpeed = 0f;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Projectiles.HereticProj>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, 0, 0, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].hostile = false;
            Main.projectile[pro].friendly = false;
            Main.projectile[pro].ai[1] = 1;
            return false;
        }
        public class HereticSpellGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(20) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Dungeon.Heretic>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.HereticSpell2>(), 1);
                    }
                }
            }
        }
    }
}