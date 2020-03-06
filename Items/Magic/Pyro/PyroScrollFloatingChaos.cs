using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollFloatingChaos : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Floating Chaos");
            Tooltip.SetDefault("Pyromancy which summons a flaming orb that projects fireballs toward your target." +
                "\nHolding causes summoned fireballs to follow the cursor");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.magic = false;
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 150;
            item.useTime = 30;
            item.useAnimation = 30;
            item.reuseDelay = 90;
            item.mana = 30;
            item.knockBack = 3f;
            item.shootSpeed = 25.0f;
            item.value = Item.sellPrice(0, 18, 50, 0);
            item.shoot = ModContent.ProjectileType<Projectiles.FloatingChaosProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int pro = Projectile.NewProjectile(position.X, position.Y - 10, 0, -5, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            Main.projectile[pro].friendly = true;
            return false;
        }
        public class ScrollFloatingChaosGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(8) == 0) {
                    if (npc.type == NPCID.MoonLordCore) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.Pyro.PyroScrollFloatingChaos>(), 1);
                    }
                }
            }
        }
    }
}